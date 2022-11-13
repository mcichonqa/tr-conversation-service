using ConversationService.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ConversationService.Entity
{
    public class ConversationContext : DbContext
    {
        public ConversationContext(DbContextOptions<ConversationContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Conversation> ConversationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}