using Common.Messages.Commands;

namespace Common.Azure.ServiceBus
{
    public interface IAzureQueueBusOptions<T>: IAzureBusOptions where T : ICommand
    {
        public string QueueName { get; set; }
    }
}