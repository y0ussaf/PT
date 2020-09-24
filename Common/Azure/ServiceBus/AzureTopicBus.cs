using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using Common.Messages.Events;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Common.Azure.ServiceBus
{
    public class AzureTopicBus<TEvent> : ITopicBus<TEvent> where TEvent : IEvent 
     {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAzureTopicBusOptions<TEvent> _options;
        private readonly ITopicClient _topicClient;
        private readonly Dictionary<string, ISubscriptionClient> _subscriptionClients;
        public AzureTopicBus(IAzureTopicBusOptions<TEvent> options,IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _options = options;
            _topicClient = new TopicClient(_options.ConnectionString,_options.TopicName);
            _subscriptionClients  = new Dictionary<string, ISubscriptionClient>();
        }
        public async Task PublishEvent(TEvent @event)
        {
            var json = JsonConvert.SerializeObject(@event);
            Message message = new Message(Encoding.UTF8.GetBytes(json));
            await _topicClient.SendAsync(message);
        }
        public Task SubscribeToEvent<THEvent>(string subscriptionName) where THEvent : IEventHandler
        {
            THEvent eventHandler =  ActivatorUtilities.CreateInstance<THEvent>(_serviceProvider);
            ISubscriptionClient subscriptionClient = null;
            if (_subscriptionClients.ContainsKey(subscriptionName))
            { 
                subscriptionClient = _subscriptionClients[subscriptionName];
            }
            else
            {
                subscriptionClient =
                    new SubscriptionClient(_options.ConnectionString, _options.TopicName, subscriptionName);
                _subscriptionClients.Add(subscriptionName,subscriptionClient);
            }
            subscriptionClient.RegisterMessageHandler(eventHandler.Handle,(e => Task.CompletedTask));

            return Task.CompletedTask;
        }
    }
}