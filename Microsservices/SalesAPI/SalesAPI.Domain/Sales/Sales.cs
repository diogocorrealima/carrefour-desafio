using SalesAPI.Domain.Core.Entities;

namespace SalesAPI.Domain.Entities
{
    public class Sales : Entity
    {
        public Sales(string id, List<Product> products)
        {
            Id = id;
            TotalValue = products.Sum(p => p.Quantity * p.Value);
            Products = products;
        }
        public double TotalValue { get; set; }
        public List<Product> Products { get; set; }
    }
}
