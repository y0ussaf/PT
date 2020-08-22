using System.Threading.Tasks;
using Common.Messages.Events;

namespace Common.Azure.ServiceBus
{
    public class AzureTopicBus : ITopicBus
    {
        public Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            throw new System.NotImplementedException();
        }

        public Task SubscribeToEvent<TEvent, THEvent>() where TEvent : IEvent where THEvent : IEventHandler
        {
            throw new System.NotImplementedException();
        }
    }
}