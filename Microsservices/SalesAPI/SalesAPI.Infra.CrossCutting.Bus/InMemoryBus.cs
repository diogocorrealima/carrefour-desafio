﻿using FluentValidation.Results;
using MediatR;
using SalesAPI.Domain.Core;

namespace SalesAPI.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            //if (!@event.MessageType.Equals("DomainNotification"))
            //    _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
