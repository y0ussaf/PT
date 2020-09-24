using Common.Messages.Events;
using MediatR;

namespace Subscription.Messages.Events
{
    public class ProductPriceChangedEvent : IEvent , IRequest
    {
        public string ProductId { get; set; }
        public double NewPrice { get; set; }
        public double OldPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
    }
}