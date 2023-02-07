using Microsoft.AspNetCore.Mvc;
using SalesAPI.Application;
using SalesAPI.Application.ViewModels;
using SalesAPI.Services.API.Controllers;

namespace SalesAPI.Services.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ApiController
{

    private readonly ILogger<SalesController> _logger;
    private readonly ISalesAppService _salesAppService;


    public SalesController(ILogger<SalesController> logger, ISalesAppService salesAppService)
    {
        _logger = logger;
        _salesAppService = salesAppService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
         return Ok(await _salesAppService.GetAll());
    }
    [HttpPost]
    public async Task Post(SalesRegisterViewModel salesRegisterViewModel)
    {
        await _salesAppService.Register(salesRegisterViewModel);
    }
}
