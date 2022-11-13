using ConversationService.Api.Model;
using ConversationService.Entity.Models;
using ConversationService.Repository;
using MassTransit;
using ScheduleService.Contract;
using System.Threading.Tasks;

namespace ConversationService.Api.Consumers.Meeting
{
    public class MeetingCreatedConsumer : IConsumer<MeetingCreatedEvent>
    {
        private readonly IConversationRepository _conversationRepository; 

        public MeetingCreatedConsumer(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task Consume(ConsumeContext<MeetingCreatedEvent> context)
        {
            var result = context.Message;

            Conversation conversation = new Conversation()
            {
                ClientId = result.ClientId,
                StartMeetingDate = result.StartMeetingDate,
                MeetingTopic = result.MeetingTopic,
                ConversationStatus = result.HasSubscription ? ConversationStatus.WaitingForApprove.ToString() : ConversationStatus.NoSubscription.ToString(),
                ConversationType = ConversationType.Hybrid.ToString(),
                ClosedBy = "Client"
            };

            await _conversationRepository.CreateConversationAsync(conversation);
        }
    }
}