using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.Filters
{
    public class UserValidation : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            bool isAuthorized = controller.User.Identity.IsAuthenticated;
            if (!isAuthorized) {
                string? returnUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
                context.Result = new RedirectToActionResult("Register", "Account", new { ReturnUrl = returnUrl });
                return;
            }
            await next();
        }
    }
}
