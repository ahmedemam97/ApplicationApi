using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Api.Core
{
    public class CustomValidationFilter : ActionFilterAttribute
    {

        public CustomValidationFilter()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = (from item in context.ModelState where item.Value.Errors.Any() select item.Value.Errors[0].ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(new BaseResponse() { Errors = errors.ToArray(), Success = false });
            }
        }
    }
}
