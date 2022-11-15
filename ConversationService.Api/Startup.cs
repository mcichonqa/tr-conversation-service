using ConversationService.Api.Consumers.Meeting;
using ConversationService.Api.Workers;
using ConversationService.Entity;
using ConversationService.Repository;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;

namespace ConversationService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConversationService", Version = "v1" });
            });

            services.AddRouting(routeOption => routeOption.LowercaseUrls = true);

            services.AddCors(options =>
                options.AddPolicy(
                    "CorsPolicy",
                    b => b.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .Build()));

            //services
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            //    {
            //        options.Authority = Configuration.GetValue<string>("AuthorityService");
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false,
            //            ClockSkew = TimeSpan.FromSeconds(1)
            //        };
            //    });

            //services.AddMassTransit(x =>
            //{
            //    x.AddConsumer<MeetingCreatedConsumer>(typeof(MeetingCreatedConsumerDefinition));

            //    x.UsingRabbitMq((context, config) =>
            //    {
            //        config.Host("localhost", "/", h => {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });

            //        config.ConfigureEndpoints(context);
            //    });
            //});

            services.AddDbContext<ConversationContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConversationDb")));
            services.AddHostedService<ConversationStatusWorker>();

            services
                 .AddControllers()
                 .AddJsonOptions(opt =>
                 {
                     opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                 });

            services.AddScoped<IConversationRepository, ConversationRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConversationService v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}