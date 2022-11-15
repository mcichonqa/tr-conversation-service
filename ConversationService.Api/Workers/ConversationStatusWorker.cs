﻿using ConversationService.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace ConversationService.Api.Workers
{
    public class ConversationStatusWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ConversationStatusWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(20000, stoppingToken);

                using (var scope = _scopeFactory.CreateScope())
                {
                    await scope.ServiceProvider
                        .GetRequiredService<IConversationRepository>()
                        .UpdateConversationsStatus();
                }
            }
        }
    }
}