using Common.Messages.Events;
using MediatR;

namespace Subscription.Messages.Events
{
    public class SubscriptionAddedEvent : IEvent,IRequest
    {
        public SubscriptionAddedEvent(string productId)
        {
            ProductId = productId;
        }

        public string ProductId { get; set; }
    }
}