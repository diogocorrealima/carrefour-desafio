using PortalWebVendas.BFF.API.DTO;
using Refit;

namespace PortalWebVendas.BFF.API.Interfaces
{
    public interface IProductService
    {
            [Get("/Product/")]
            Task<List<ProductDto>> GetAll([Query(CollectionFormat.Multi)] List<string> ids);
        
    }
}
