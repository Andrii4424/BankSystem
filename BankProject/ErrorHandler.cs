using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BankProject
{
    public static class ErrorHandler
    {
        public static List<string> PrintErrorList(ModelStateDictionary ModelState, HttpContext context)
        {
            List<string> errors = new List<string>();
            context.Response.StatusCode = 400;
            foreach (var item in ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors;
        }
    }
}
