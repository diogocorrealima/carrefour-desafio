using Microsoft.AspNetCore.Mvc;
using PortalWebVendas.BFF.API.DTO;
using PortalWebVendas.BFF.API.Interfaces;

namespace PortalWebVendas.BFF.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;
        private readonly ISalesService _salesService;
        private readonly IProductService _productsService;

        public SalesController(ILogger<SalesController> logger, ISalesService salesService, IProductService productsService)
        {
            _logger = logger;
            _salesService = salesService;
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<List<SalesDto>> Get()
        {
            return await _salesService.GetAll();
        }
        [HttpPost]
        public async Task Post(SalesRegisterDto salesDto)
        {
            var products = await _productsService.GetAll(salesDto.Products.Select(p => p.Id).ToList());
            salesDto.Products = products;
            await _salesService.Register(salesDto);
        }
    }
}