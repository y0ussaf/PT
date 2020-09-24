using System.Threading.Tasks;

namespace Common.Messages.Commands
{
    public interface IQueueBus<TCommand> where  TCommand : ICommand
    {
        Task SendCommand(TCommand command);
        Task SubscribeToCommand<THCommand>() where THCommand : ICommandHandler;
    }
}