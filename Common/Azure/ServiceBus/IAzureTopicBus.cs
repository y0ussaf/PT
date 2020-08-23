namespace Common.Azure.ServiceBus
{
    public interface IAzureTopicBus<T> : IAzureBusOptions
    {
        public string TopicName { get; set; }
    }
}