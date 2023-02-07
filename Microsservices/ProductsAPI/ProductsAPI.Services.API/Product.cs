using System.Xml.Linq;

namespace ProductsAPI.Services.API;

public class Product
{
    public Product(string id, string name, double value, int quantity)
    {
        Id = id;
        Value = value;
        Name = name;
        Quantity = quantity;
    }
    public Product(string name, double value, int quantity)
    {
        Id = Guid.NewGuid().ToString();
        Value = value;
        Name = name;
        Quantity = quantity;

    }

    public string Id { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public int Quantity { get; set; }
}
