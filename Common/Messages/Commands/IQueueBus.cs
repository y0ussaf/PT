using System.Threading.Tasks;

namespace Common.Messages.Commands
{
    public interface IQueueBus
    {
        Task SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
        Task SubscribeToCommand<TCommand, THCommand>() where TCommand : ICommand where THCommand : ICommandHandler;
    }
}