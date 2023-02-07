using PortalWebVendas.BFF.API.DTO;
using Refit;

namespace PortalWebVendas.BFF.API.Interfaces
{
    public interface ISalesService
    {
            [Get("/Sales/")]
            Task<List<SalesDto>> GetAll();
        
            [Post("/Sales/")]
            Task Register(SalesDto sales);
    }
}
