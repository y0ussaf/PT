using MediatR;
using Subscription.Domain;

namespace Subscription.Commands
{
    public class SubscribeCommand : IRequest<bool>
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public double Threshold { get; private set; }
        public string ProductUrl { get; private set; }
        public Mode Mode { get; private set; }

        public SubscribeCommand(string email, string name, double threshold, string productUrl, Mode mode)
        {
            Email = email;
            Name = name;
            Threshold = threshold;
            ProductUrl = productUrl;
            Mode = mode;
        }
    }
}