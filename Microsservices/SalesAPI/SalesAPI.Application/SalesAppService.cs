using AutoMapper;
using FluentValidation.Results;
using MediatR;
using SalesAPI.Application.ViewModels;
using SalesAPI.Domain.Commands;
using SalesAPI.Domain.Entities;
using SalesAPI.Domain.Interfaces;

namespace SalesAPI.Application
{
    public class SalesAppService : ISalesAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISalesRepository _salesRepository;
        public SalesAppService(IMediator mediator, IMapper mapper, ISalesRepository salesRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _salesRepository = salesRepository; 
        }
        public async Task<List<SalesListViewModel>> GetAll()
        {
            var sales = _mapper.Map<List<SalesListViewModel>>(await _salesRepository.GetAllAsync());
            return sales;
        }
        public async Task<ValidationResult> Register(SalesRegisterViewModel salesRegisterViewModel)
        {
            var registerCommand = new RegisterSalesCommand(salesRegisterViewModel.TotalValue, _mapper.Map<List<Product>>(salesRegisterViewModel.Products));
            return await _mediator.Send(registerCommand);
        }
    }
}