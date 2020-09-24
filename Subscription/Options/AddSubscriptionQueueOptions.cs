using Common.Azure.ServiceBus;
using Subscription.Messages.Commands;

namespace Subscription.Options
{
    public class AddSubscriptionQueueOptions : IAzureQueueBusOptions<AddSubscriptionCommand>
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
    }
}