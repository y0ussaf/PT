using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Common.Messages.Commands
{
    public interface ICommandHandler
    {
        Task Handle(Message message, CancellationToken cancellationToken);
    }
}