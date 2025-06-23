using BankServicesContracts.ServicesContracts;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
namespace BankProject.Controllers
{
    public class HomeController : Controller
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
            return View();
        }

        [HttpGet("/error")]
        public IActionResult Error() { 
            IExceptionHandlerPathFeature? feature =HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (feature != null && feature.Error != null) { 
                ViewBag.ErrorMessage = feature.Error.Message;
                HttpContext.Response.StatusCode = 400;
            }
            return View();
        }
    }
}
