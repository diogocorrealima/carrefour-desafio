using Microsoft.AspNetCore.Mvc;

namespace ProductsAPI.Services.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {     

        private readonly ILogger<ProductController> _logger;
        public List<Product> products = new List<Product>();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            products  = new List<Product>
    {   new Product("cf1ec0f1-681c-4506-8315-f51a55ab3b42","PS5", 10, 20),
        new Product("6e6dc5af-5d54-4890-8f0a-fe6a1510dab2","XBOX 360", 20, 20),
        new Product("4b246255-c09c-4653-8283-40d677c32c17","Nintendo Wii", 20, 20) };
    }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]List<string> ids)
        {
            return Ok(await Task.FromResult(products.Where(p => ids.Contains(p.Id)).ToList()));
        }
    }
}