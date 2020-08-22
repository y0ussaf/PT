using System.Threading.Tasks;
using Common.Messages.Commands;

namespace Common.Azure.ServiceBus
{
    public class AzureQueueBus : IQueueBus
    {
        public Task SendCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            throw new System.NotImplementedException();
        }

        public Task SubscribeToCommand<TCommand, THCommand>() where TCommand : ICommand where THCommand : ICommandHandler
        {
            throw new System.NotImplementedException();
        }
    }
}