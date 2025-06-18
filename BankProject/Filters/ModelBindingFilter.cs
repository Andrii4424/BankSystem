using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankProject.Filters
{
    public class ModelBindingFilter : IAsyncActionFilter
    {
        private readonly ILogger<ModelBindingFilter> _logger;
        public string ActionName { get; set; }

        public ModelBindingFilter(ILogger<ModelBindingFilter> logger, string actionName)
        {
            _logger = logger;
            ActionName = actionName;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<string> errors = new List<string>();
            var controller = context.Controller as Controller;
            if (!context.ModelState.IsValid)
            {
                _logger.LogWarning("POST /{ActionName} -> Invalid model", ActionName);
                controller.ViewBag.Message = "Error";
                errors = ErrorHandler.PrintErrorList(context.ModelState, context.HttpContext);
                controller.ViewBag.Errors = errors;
            }
            else
            {
                controller.ViewBag.Message = "Success!";
                controller.ViewBag.Errors = null;
                _logger.LogInformation("POST /{ActionName} -> Success adding object", ActionName);
            }
            await next();
        }
    }
}
