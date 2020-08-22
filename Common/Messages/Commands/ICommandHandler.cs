using System.Threading.Tasks;

namespace Common.Messages.Commands
{
    public interface ICommandHandler
    {
        Task Handle(ICommand command);
    }
}