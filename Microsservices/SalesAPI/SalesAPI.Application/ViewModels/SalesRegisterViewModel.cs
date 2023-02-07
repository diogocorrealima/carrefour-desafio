using SalesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Application.ViewModels
{
    public class SalesRegisterViewModel
    {
        public SalesRegisterViewModel()
        {
            TotalValue = 0;
            Products = new List<ProductViewModel>();
        }
        public double TotalValue { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
