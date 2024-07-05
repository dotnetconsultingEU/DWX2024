using Microsoft.AspNetCore.Mvc.Filters;

namespace DWX2024.WebApi.Code.ExceptionHandler;

public sealed class ArgumentOutOfRangeExceptionHandler : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is ArgumentOutOfRangeException ex)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ArgumentOutOfRangeExceptionHandler>>();

            logger?.LogError(ex, "ArgumentOutOfRangeException");

            context.HttpContext.Response.StatusCode = 404;
            context.ExceptionHandled = true;
        }

        base.OnException(context);
    }
}
