using System.Collections.Generic;
using System.Threading.Tasks;
using Subscription.Domain;

namespace Subscription.Repository
{
    public interface ISubscriptionsRepo
    {
        public Task RegisterSubscription(AmazonProductSubscription subscription);
        Task<List<AmazonProductSubscription>> GetSubscriptions(string requestProductId, string requestLocation);
    }
}