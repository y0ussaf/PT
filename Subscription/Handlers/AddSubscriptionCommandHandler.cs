using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscription.Messages.Commands;
using Subscription.Repository;

namespace Subscription.Handlers
{
    public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand,bool>
    {
        private readonly ISubscriptionsRepo _subscriptionsRepo;

        public AddSubscriptionCommandHandler(ISubscriptionsRepo subscriptionsRepo)
        {
            _subscriptionsRepo = subscriptionsRepo;
        }

        public Task<bool> Handle(AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}