using AutoMapper;
using SalesAPI.Application.ViewModels;
using SalesAPI.Domain.Commands;
using SalesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<SalesRegisterViewModel, RegisterSalesCommand>()
                .ConstructUsing(c => new RegisterSalesCommand(c.TotalValue, null));

        }
    }
}