using Common.Messages;
using Common.Messages.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions
{
    public  static class MessageBusExtensions
    {
        public static void SubscribeToEvent<TEvent,THEvent>(this IApplicationBuilder app) where TEvent : IEvent where THEvent : IEventHandler
        {
            IMessageBus messageBus =  app.ApplicationServices.GetService<IMessageBus>();
            messageBus.SubscribeToEvent<TEvent, THEvent>();
            
        }
    }
}