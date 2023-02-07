using SalesAPI.Domain.Core;
using SalesAPI.Domain.Entities;


namespace SalesAPI.Domain.Events
{
    public class SalesRegisteredEvent : Event
    {
        public SalesRegisteredEvent(string id, double totalValue, List<Product> products)
        {
            Id = id;
            TotalValue = totalValue;
            Products = products;
        }
        public string Id { get; set; }
        public double TotalValue { get; set; }
        public List<Product> Products { get; set; }
    }
}
