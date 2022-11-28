using ConversationService.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConversationService.Repository
{
    public interface IConversationRepository
    {
        Task<Conversation> GetConversationAsync(int id);
        Task<List<Conversation>> GetConversationsAsync();
        Task<int> CreateConversationAsync(Conversation conversation);
        Task UpdateConversationAsync(Conversation conversation);
    }
}