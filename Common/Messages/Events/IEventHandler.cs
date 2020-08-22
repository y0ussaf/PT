using System.Threading.Tasks;
 
namespace Common.Messages.Events
{
    public interface IEventHandler
    {
        Task Handle(IEvent @event);
    }
}