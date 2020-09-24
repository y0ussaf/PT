using Common.Azure.ServiceBus;
using Common.Extensions;
using Common.Messages.Commands;
using Common.Messages.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subscription.Messages.Commands;
using Subscription.Messages.Events;
using Subscription.Messages.Handlers;
using Subscription.Options;

namespace Subscription.Extensions
{
    public static class MessageBus
    {
        public  static void AddAzureServiceBus(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAzureQueueBus<AddSubscriptionCommand>();
            
            services.Configure<AddSubscriptionQueueOptions>(configuration.GetSection("Messaging:AzureServiceBus:AddSubscriptionQueue"));
            
            services.AddAzureTopicBus<SubscriptionAddedEvent>();
            
            services.Configure<SubscriptionAddedTopicOptions>(configuration.GetSection("Messaging:AzureServiceBus:AddSubscriptionTopic"));
            
        }

        public static void RegisterCommandsHandlers(this IApplicationBuilder app)
        {
            IQueueBus<AddSubscriptionCommand> queueBus1 = 
                app.ApplicationServices.GetService<IQueueBus<AddSubscriptionCommand>>();
            queueBus1.SubscribeToCommand<AddSubscriptionCommandHandler>();
        }

        public static void RegisterEventsHandlers(this IApplicationBuilder app)
        {
            ITopicBus<ProductPriceChangedEvent> topicBus1 =
                app.ApplicationServices.GetService<ITopicBus<ProductPriceChangedEvent>>();
            topicBus1.SubscribeToEvent<ProductPriceChangedHandler>("s1");
        }
    }
}