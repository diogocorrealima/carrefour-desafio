namespace PortalWebVendas.BFF.API.DTO
{
    public class SalesDto
    {
        public SalesDto()
        {
            Products = new List<ProductDto>();
        }
        public string Id { get; set; }
        public double TotalValue { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
