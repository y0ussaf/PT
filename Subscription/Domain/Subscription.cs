using System;

namespace Subscription.Domain
{
    public class AmazonProductSubscription
    {
        public double Threshold { get; }
        public string ProductId { get; }
        public string Location { get; }
        public Guid UserId { get; }
        public AmazonProductSubscription(Guid id,double threshold,Mode mode,Guid userId, string productId, string location)
        {
            if (threshold < 0)
            {
                throw  new Exception("invalid threshold");
            }
            Threshold = threshold;
            UserId = userId;
            ProductId = productId;
            Location = location;
        }
    }

    public enum Mode
    {
        Gt,
        Lt,
        Ge,
        Le,
        Eq
    }
}