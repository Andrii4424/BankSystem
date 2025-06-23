using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            _logger.LogDebug("GET / -> rendering welcome page");
            return Ok();
        }

        [HttpGet("/error")]
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature? feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (feature != null && feature.Error != null)
            {
                HttpContext.Response.StatusCode = 400;
            }
            return Problem();
        }
    }
}
