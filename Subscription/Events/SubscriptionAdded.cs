namespace Subscription.Events
{
    public class SubscriptionAdded
    {
        public SubscriptionAdded(string productId)
        {
            ProductId = productId;
        }

        public string ProductId { get; private set; }
    }
}