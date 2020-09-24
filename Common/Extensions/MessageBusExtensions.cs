using Common.Azure.ServiceBus;
using Common.Messages;
using Common.Messages.Commands;
using Common.Messages.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions
{
    public  static class MessageBusExtensions
    {
        public  static void AddAzureQueueBus<T>(this IServiceCollection serviceCollection) where T : ICommand
        {
            serviceCollection.AddSingleton<IQueueBus<T>, AzureQueueBus<T>>();
        }

        public static void AddAzureTopicBus<T>(this IServiceCollection serviceCollection) where T : IEvent
        {
            serviceCollection.AddSingleton<ITopicBus<T>, AzureTopicBus<T>>();
        }
        
    }
}