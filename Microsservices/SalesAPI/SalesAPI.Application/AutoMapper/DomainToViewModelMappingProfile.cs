using AutoMapper;
using SalesAPI.Application.ViewModels;
using SalesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Sales, SalesRegisterViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Sales, SalesListViewModel>();

        }
    }
}