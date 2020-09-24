using System.Threading.Tasks;

namespace Common.Messages.Events
{
    public interface ITopicBus<TEvent> where TEvent : IEvent
    {
        Task PublishEvent(TEvent @event);
        Task SubscribeToEvent<THEvent>(string subscriptionName) where THEvent : IEventHandler;


    }
}