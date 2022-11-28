using ConversationService.Entity.Models;
using System.Threading.Tasks;

namespace ConversationService.Application
{
    public interface IConversationsService
    {
        Task<int> CreateConversationAsync(Conversation conversation);
        Task<int> UpdateConversationsStatusAsync();
        Task UpdateCanceledConversastion(int meetingId);
    }
}