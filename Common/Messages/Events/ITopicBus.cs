using System.Threading.Tasks;

namespace Common.Messages.Events
{
    public interface ITopicBus
    {
        Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
        Task SubscribeToEvent<TEvent, THEvent>() where TEvent : IEvent where THEvent : IEventHandler;


    }
}