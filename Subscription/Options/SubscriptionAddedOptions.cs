using Common.Azure.ServiceBus;
using Subscription.Messages.Events;

namespace Subscription.Options
{
    public class SubscriptionAddedTopicOptions : IAzureTopicBusOptions<SubscriptionAddedEvent>
    {
        public string ConnectionString { get; set; }
        public string TopicName { get; set; }
    }
}