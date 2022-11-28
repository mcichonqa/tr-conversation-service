using ConversationService.Application;
using MassTransit;
using ScheduleService.Contract;
using System.Threading.Tasks;

namespace ConversationService.Api.Consumers.Meeting
{
    public class MeetingCanceledConsumer : IConsumer<MeetingCanceledEvent>
    {
        private readonly IConversationsService _conversationsService;

        public MeetingCanceledConsumer(IConversationsService conversationsService)
        {
            _conversationsService = conversationsService;
        }

        public async Task Consume(ConsumeContext<MeetingCanceledEvent> context)
        {
            var result = context.Message;
            await _conversationsService.UpdateCanceledConversastion(result.Id);
        }
    }
}