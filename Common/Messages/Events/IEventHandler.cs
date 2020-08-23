using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Common.Messages.Events
{
    public interface IEventHandler
    {
        Task Handle(Message message, CancellationToken cancellationToken);
    }
}