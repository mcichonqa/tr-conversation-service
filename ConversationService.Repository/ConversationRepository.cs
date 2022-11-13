using ConversationService.Entity;
using ConversationService.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ConversationService.Repository
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ConversationContext _dbContext;

        public ConversationRepository(ConversationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Conversation> GetConversationAsync(int id)
        {
            return await _dbContext.ConversationDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CreateConversationAsync(Conversation conversation)
        {
            await _dbContext.AddAsync(conversation);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(conversation.Id);
        }
    }
}