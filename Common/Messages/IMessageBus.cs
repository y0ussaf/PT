using System.Threading.Tasks;
using Common.Messages.Commands;
using Common.Messages.Events;

namespace Common.Messages
{
    public interface IMessageBus
    {
        Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent;
        Task SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
        Task SubscribeToCommand<TCommand, THCommand>() where TCommand : ICommand where THCommand : ICommandHandler;
        Task SubscribeToEvent<TEvent, THEvent>() where TEvent : IEvent where THEvent : IEventHandler;

    }

   
}