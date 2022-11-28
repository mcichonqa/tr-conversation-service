using ConversationService.Entity;
using ConversationService.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Conversation>> GetConversationsAsync()
        {
            return await _dbContext.ConversationDetails.ToListAsync();
        }

        public async Task<Conversation> GetConversationAsync(int meetingId)
        {
            return await _dbContext.ConversationDetails.FirstOrDefaultAsync(x => x.MeetingId == meetingId);
        }

        public async Task<int> CreateConversationAsync(Conversation conversation)
        {
            await _dbContext.ConversationDetails.AddAsync(conversation);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(conversation.Id);
        }

        public async Task UpdateConversationAsync(Conversation conversation)
        {
            _dbContext.ConversationDetails.Update(conversation);
            await _dbContext.SaveChangesAsync();
        }
    }
}