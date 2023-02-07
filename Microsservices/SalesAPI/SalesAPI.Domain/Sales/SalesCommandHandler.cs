using FluentValidation.Results;
using MediatR;
using SalesAPI.Domain.Commands;
using SalesAPI.Domain.Core;
using SalesAPI.Domain.Entities;
using SalesAPI.Domain.Events;
using SalesAPI.Domain.Interfaces;

namespace SalesAPI.Domain.CommandHandlers
{
    public class SalesCommandHandler : CommandHandler, IRequestHandler<RegisterSalesCommand, ValidationResult>
    {
        private readonly ISalesRepository _salesRepository;
        public SalesCommandHandler(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }
        public async Task<ValidationResult> Handle(RegisterSalesCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var sales = new Sales(Guid.NewGuid().ToString(), request.Products);

            //if (await _salesRepository.GetByEmail(sales.Email) != null)
            //{
            //    AddError("The customer e-mail has already been taken.");
            //    return ValidationResult;
            //}

            sales.AddDomainEvent(new SalesRegisteredEvent(sales.Id, sales.TotalValue, sales.Products));

            _salesRepository.Add(sales);

            return await Commit(_salesRepository.UnitOfWork);
        }
    }
}
