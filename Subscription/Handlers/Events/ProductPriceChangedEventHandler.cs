using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.ProductUrlInfosExtractors;
using MediatR;
using Subscription.Domain;
using Subscription.Messages.Events;
using Subscription.Repository;

namespace Subscription.Handlers.Events
{
    public class ProductPriceChangedEventHandler : IRequestHandler<ProductPriceChangedEvent>
    {
        private readonly ISubscriptionsRepo _subscriptionsRepo;

        public ProductPriceChangedEventHandler(ISubscriptionsRepo subscriptionsRepo)
        {
            _subscriptionsRepo = subscriptionsRepo;
        }

        public async Task<Unit> Handle(ProductPriceChangedEvent request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionsRepo.GetSubscriptions(request.ProductId, request.Location);
            return Unit.Value;
        }
    }
}