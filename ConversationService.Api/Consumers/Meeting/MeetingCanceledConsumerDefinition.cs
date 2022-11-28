using MassTransit;

namespace ConversationService.Api.Consumers.Meeting
{
    public class MeetingCanceledConsumerDefinition : ConsumerDefinition<MeetingCanceledConsumer>
    {
        public MeetingCanceledConsumerDefinition()
        {
            EndpointName = "meeting.canceled.queue";
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MeetingCanceledConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}