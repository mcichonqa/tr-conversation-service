using MassTransit;

namespace ConversationService.Api.Consumers.Meeting
{
    public class MeetingCreatedConsumerDefinition : ConsumerDefinition<MeetingCreatedConsumer>
    {
        public MeetingCreatedConsumerDefinition()
        {
            EndpointName = "meeting.created.queue";
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<MeetingCreatedConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}