using SalesAPI.Domain.Core.Entities;

namespace SalesAPI.Application.ViewModels
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }
    }
}