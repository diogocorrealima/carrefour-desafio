using PortalWebVendas.BFF.API.DTO;
using PortalWebVendas.BFF.API.Interfaces;
using Refit;
using static PortalWebVendas.BFF.API.Services.SalesService;

namespace PortalWebVendas.BFF.API.Services
{
    public class ProductService : IProductService
    {
            private readonly IProductService _productsService;

            public ProductService(IConfiguration configuration)
            {
            _productsService = RestService.For<IProductService>(configuration.GetSection("Applications:ProductsAPI").Value);

            }

        public async Task<List<ProductDto>> GetAll(List<string> ids)
        {
            return await _productsService.GetAll(ids);
        }

        
    }
}
