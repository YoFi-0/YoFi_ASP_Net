using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Yofi_ASP_Net.Middlewares
{
    [AttributeUsage(AttributeTargets.Method)]

    public class IsLogin : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var qrLogin = context.HttpContext.Request.Query["login"];
            if (qrLogin != "true")
            {
                context.HttpContext.Response.Redirect("/Auth");
                return;
            }
            await next();

        }
    }
}
