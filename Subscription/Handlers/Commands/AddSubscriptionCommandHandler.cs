using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Helpers.ProductUrlInfosExtractors;
using MediatR;
using Subscription.Domain;
using Subscription.Messages.Commands;
using Subscription.Repository;

namespace Subscription.Handlers.Commands
{
    public class AddSubscriptionCommandHandler : IRequestHandler<AddSubscriptionCommand,bool>
    {
        private readonly ISubscriptionsRepo _subscriptionsRepo;
        private readonly IProductUrlInfosExtractor _productUrlInfosExtractor;


        public AddSubscriptionCommandHandler(ISubscriptionsRepo subscriptionsRepo,IProductUrlInfosExtractor productUrlInfosExtractor)
        {
            _subscriptionsRepo = subscriptionsRepo;
            _productUrlInfosExtractor = productUrlInfosExtractor;
        }

        public async Task<bool> Handle(AddSubscriptionCommand command, CancellationToken cancellationToken)
        {
            ProductUrlInfos productUrlInfos = _productUrlInfosExtractor.Extract(command.ProductUrl);
            if (productUrlInfos.Success)
            {
                AmazonProductSubscription subscription = new AmazonProductSubscription(Guid.NewGuid(), command.Threshold,command.Mode,
                    Guid.NewGuid(),productUrlInfos.ProductId,productUrlInfos.Location);
                try
                {
                   await _subscriptionsRepo.RegisterSubscription(subscription);
                   return true;
                }
                catch (Exception e)
                {
                    //
                }
            }
            return false;


        }
    }
}