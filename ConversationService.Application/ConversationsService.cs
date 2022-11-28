using ConversationService.Entity.Models;
using ConversationService.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConversationService.Application
{
    public class ConversationsService : IConversationsService
    {
        private readonly IConversationRepository _conversationRepository;

        public ConversationsService(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<int> CreateConversationAsync(Conversation conversation)
        {
            return await _conversationRepository.CreateConversationAsync(conversation);
        }

        public async Task UpdateCanceledConversastion(int meetingId)
        {
            var conversation = await _conversationRepository.GetConversationAsync(meetingId);
            conversation.ConversationStatus = ConversationStatus.Canceled.ToString();

            await _conversationRepository.UpdateConversationAsync(conversation);
        }

        public async Task<int> UpdateConversationsStatusAsync()
        {
            var conversations = await _conversationRepository.GetConversationsAsync();

            var conversationsForUpdate = conversations.Where(
                item => item.ConversationStatus == ConversationStatus.WaitingForMeeting.ToString() && item.StartMeetingDate.Subtract(DateTime.UtcNow).TotalSeconds <= 60);
               
            int conversationsCount = conversationsForUpdate.Count();

            foreach(var conversation in conversationsForUpdate)
            {
                conversation.ConversationStatus = ConversationStatus.WaitingForJoin.ToString();
                await _conversationRepository.UpdateConversationAsync(conversation);
            }

            return await Task.FromResult(conversationsCount);
        }
    }
}