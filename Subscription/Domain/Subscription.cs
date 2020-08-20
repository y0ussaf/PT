using System;

namespace Subscription.Domain
{
    public class Subscription
    {
        public double Threshold { get; private set; }
        public Guid UserId { get; private set; }
        public Subscription(Guid id,double threshold,Mode mode,Guid userId )
        {
            if (threshold < 0)
            {
                throw  new Exception("invalid threshold");
            }
            Threshold = threshold;
            UserId = userId;
            
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