using ConversationService.Entity.Models;
using System.Threading.Tasks;

namespace ConversationService.Repository
{
    public interface IConversationRepository
    {
        Task<Conversation> GetConversationAsync(int id);
        Task<int> CreateConversationAsync(Conversation conversation);
        Task<int> UpdateConversationsStatus();
    }
}