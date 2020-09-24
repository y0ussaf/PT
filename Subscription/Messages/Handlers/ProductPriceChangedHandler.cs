using System.Threading;
using System.Threading.Tasks;
using Common.Messages.Events;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Subscription.Messages.Events;

namespace Subscription.Messages.Handlers
{
    public class ProductPriceChangedHandler : IEventHandler
    {
        private readonly IMediator _mediator;

        public ProductPriceChangedHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task Handle(Message message, CancellationToken cancellationToken)
        {
            ProductPriceChangedEvent priceChangedEvent = JsonConvert.DeserializeObject<ProductPriceChangedEvent>(message.Body.ToString());
            _mediator.Send(priceChangedEvent,cancellationToken);
            return Task.CompletedTask;
        }
    }
}