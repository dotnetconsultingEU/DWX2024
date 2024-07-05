using Microsoft.AspNetCore.Mvc.Filters;

namespace DWX2024.WebApi.Code.ExceptionHandler;

public sealed class TaskCanceledExceptionHandler : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is TaskCanceledException ex)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<TaskCanceledExceptionHandler>>();

            logger?.LogError(ex, "TaskCanceledException");

            // Nginx' non-standard code 499 or 444.
            context.HttpContext.Response.StatusCode = 499;
            context.ExceptionHandled = true;
        }

        base.OnException(context);
    }
}