using PortalWebVendas.BFF.API.DTO;
using PortalWebVendas.BFF.API.Interfaces;
using Refit;
using static PortalWebVendas.BFF.API.Services.SalesService;

namespace PortalWebVendas.BFF.API.Services
{
    public class SalesService : ISalesService
    {
            private readonly ISalesService _salesService;

            public SalesService(IConfiguration configuration)
            {
                _salesService = RestService.For<ISalesService>(configuration.GetSection("Applications:SalesAPI").Value);

            }

        public async Task<List<SalesDto>> GetAll()
        {
            return await _salesService.GetAll();
        }

        public async Task Register(SalesRegisterDto sales)
        {
            await _salesService.Register(sales);
        }
    }
}
