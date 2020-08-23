namespace Common.Azure.ServiceBus
{
    public interface IAzureQueueBusOptions<T> : IAzureBusOptions
    {
        public string QueueName { get; set; }
    }
}