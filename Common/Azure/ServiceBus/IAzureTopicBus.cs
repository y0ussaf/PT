using Common.Messages.Events;

namespace Common.Azure.ServiceBus
{
    public interface IAzureTopicBusOptions<TEvent> : IAzureBusOptions where TEvent : IEvent
    {
        public string TopicName { get; set; }
    }
}