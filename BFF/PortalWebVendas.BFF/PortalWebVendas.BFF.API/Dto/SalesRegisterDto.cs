namespace PortalWebVendas.BFF.API.DTO
{
    public class SalesRegisterDto
    {
        public SalesRegisterDto()
        {
            Products = new List<ProductDto>();
        }
        public List<ProductDto> Products { get; set; }
    }
}
