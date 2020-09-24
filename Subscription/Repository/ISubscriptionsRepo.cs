using System.Threading.Tasks;

namespace Subscription.Repository
{
    public interface ISubscriptionsRepo
    {
        public Task RegisterSubscription(Domain.Subscription subscription);
    }
}