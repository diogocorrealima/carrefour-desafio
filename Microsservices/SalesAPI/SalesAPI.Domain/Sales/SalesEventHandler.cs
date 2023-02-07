using MediatR;
using SalesAPI.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Domain.EventHandlers
{
    public class SalesEventHandler : INotificationHandler<SalesRegisteredEvent>
    {
        public Task Handle(SalesRegisteredEvent notification, CancellationToken cancellationToken)
        {

            //Send event to EventBus
            //Send email
            //Send sms
            return Task.CompletedTask;
        }
    }
}
