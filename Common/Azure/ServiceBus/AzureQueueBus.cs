using System;
using System.Text;
using System.Threading.Tasks;
using Common.Messages.Commands;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Common.Azure.ServiceBus
{
    public class AzureQueueBus<T,TCommand> : IQueueBus<T,TCommand> where TCommand : ICommand
    {
        private readonly IAzureQueueBusOptions<T> _options;
        private readonly IServiceProvider _serviceProvider;
        private readonly IQueueClient _queueClient;
        public AzureQueueBus(IAzureQueueBusOptions<T> options,IServiceProvider serviceProvider)
        {
            _options = options;
            _serviceProvider = serviceProvider;
            _queueClient = new QueueClient(_options.ConnectionString,_options.QueueName);
        }

        public async Task SendCommand(TCommand command) 
        {
            var json = JsonConvert.SerializeObject(command);
            Message message = new Message(Encoding.UTF8.GetBytes(json));
            await _queueClient.SendAsync(message);
        }

        public Task SubscribeToCommand<THCommand>() where THCommand : ICommandHandler
        {
            THCommand eventHandler =  ActivatorUtilities.CreateInstance<THCommand>(_serviceProvider);
            _queueClient.RegisterMessageHandler(eventHandler.Handle,e => Task.CompletedTask);
            return Task.CompletedTask;
        }
    }
}