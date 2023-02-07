using FluentValidation.Results;
using MediatR;
using SalesAPI.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Infra.CrossCutting.Bus
{
    //public class MediatorHandler : IMediatorHandler
    //{
    //    private readonly IMediator _mediator;

    //    public MediatorHandler(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public virtual Task<ValidationResult> SendCommand<T>(T command) where T : Command
    //    {
    //        return _mediator.Send(command);
    //    }

    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public virtual Task PublishEvent<T>(T @event) where T : Event
    //    {
    //        return _mediator.Publish(@event);
    //    }
    //}
}
