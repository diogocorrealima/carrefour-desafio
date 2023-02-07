using SalesAPI.Domain.Core;
using SalesAPI.Domain.Entities;

namespace SalesAPI.Domain.Commands
{
    public class RegisterSalesCommand : Command
    {
        public RegisterSalesCommand(double totalValue, List<Product> products)
        {
            TotalValue = totalValue;
            Products = products;
        }
        public double TotalValue { get; set; }
        public List<Product> Products { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
