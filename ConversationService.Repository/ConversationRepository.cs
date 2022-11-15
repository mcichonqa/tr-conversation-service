using ConversationService.Entity;
using ConversationService.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            await _dbContext.ConversationDetails.AddAsync(conversation);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(conversation.Id);
        }

        public async Task<int> UpdateConversationsStatus()
        {
            var conversationsForUpdate = _dbContext.ConversationDetails.Where(item => item.ConversationStatus == ConversationStatus.Approved.ToString() && EF.Functions.DateDiffSecond(item.StartMeetingDate, DateTime.UtcNow) <= 60);
            int conversations = await conversationsForUpdate.CountAsync();

            await conversationsForUpdate.ForEachAsync(x => x.ConversationStatus = ConversationStatus.WaitingToJoin.ToString());

            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(conversations);
        }
    }
}