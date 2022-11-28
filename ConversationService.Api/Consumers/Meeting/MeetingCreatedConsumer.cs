using ConversationService.Application;
using ConversationService.Entity.Models;
using MassTransit;
using ScheduleService.Contract;
using System.Threading.Tasks;

namespace ConversationService.Api.Consumers.Meeting
{
    public class MeetingCreatedConsumer : IConsumer<MeetingCreatedEvent>
    {
        private readonly IConversationsService _conversationServices; 

        public MeetingCreatedConsumer(IConversationsService conversationServices)
        {
            _conversationServices = conversationServices;
        }

        public async Task Consume(ConsumeContext<MeetingCreatedEvent> context)
        {
            var result = context.Message;

            Conversation conversation = new Conversation()
            {
                ClientId = result.ClientId,
                StartMeetingDate = result.StartMeetingDate,
                MeetingTopic = result.MeetingTopic,
                ConversationStatus = ConversationStatus.WaitingForMeeting.ToString(),
                ClosedBy = string.Empty,
                MeetingId = result.Id
            };

            await _conversationServices.CreateConversationAsync(conversation);
        }
    }
}