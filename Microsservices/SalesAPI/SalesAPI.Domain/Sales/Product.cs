using SalesAPI.Domain.Core.Entities;

namespace SalesAPI.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string id, double value, int quantity)
        {
            Id = id;
            Value = value;
            Quantity = quantity;    
        }
        public double Value { get; set; }
        public int Quantity { get; set; }
    }
}