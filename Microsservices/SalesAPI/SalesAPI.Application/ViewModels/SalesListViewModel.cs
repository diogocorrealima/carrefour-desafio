using SalesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Application.ViewModels
{
    public class SalesListViewModel
    {
        public SalesListViewModel()
        {
            Products = new List<ProductViewModel>();
        }
        public string Id { get; set; }
        public double TotalValue { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
