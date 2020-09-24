using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Messages.Commands;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Subscription.Messages.Commands;

namespace Subscription.Messages.Handlers
{
    public class AddSubscriptionCommandHandler : ICommandHandler
    {
        private readonly IMediator _mediator;

        public AddSubscriptionCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Handle(Message message, CancellationToken cancellationToken)
        {
             AddSubscriptionCommand subscribeCommand = JsonConvert.DeserializeObject<AddSubscriptionCommand>(message.Body.ToString());
             _mediator.Send(subscribeCommand,cancellationToken);
             return Task.CompletedTask;
        }
    }
}