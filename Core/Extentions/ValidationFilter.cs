using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentions
{
    public class ValidationFilter : IActionFilter, IAsyncActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var contextX = context;
            var RouteData = context.RouteData;
            var HttpContext = context.HttpContext;


            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
           
            if (param == null)
            {
                context.Result = new BadRequestObjectResult($"Object is null");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var contextX = context;
            var RouteData = context.RouteData;
            var HttpContext = context.HttpContext;


            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            if (param == null)
            {
                context.Result = new BadRequestObjectResult($"Object is null");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
