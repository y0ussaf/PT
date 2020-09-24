using Common.Messages.Commands;
using MediatR;
using Subscription.Domain;

namespace Subscription.Messages.Commands
{
    public class AddSubscriptionCommand : IRequest<bool> , ICommand
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public double Threshold { get; private set; }
        public string ProductUrl { get; private set; }
        public Mode Mode { get; private set; }

        public AddSubscriptionCommand(string email, string name, double threshold, string productUrl, Mode mode)
        {
            Email = email;
            Name = name;
            Threshold = threshold;
            ProductUrl = productUrl;
            Mode = mode;
        }
    }
}