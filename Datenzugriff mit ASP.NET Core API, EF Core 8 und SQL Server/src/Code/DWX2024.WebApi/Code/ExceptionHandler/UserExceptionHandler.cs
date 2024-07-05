using DWX2024.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DWX2024.WebApi.Code.ExceptionHandler;

public sealed class UserExceptionHandler : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is UserException userEx)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<UserExceptionHandler>>(); ;

            logger?.LogError("UserException: {userEx.Details}", userEx.Details);

            context.Result = new ObjectResult(UserErrorDetails.Create(userEx));
            context.HttpContext.Response.StatusCode = 400;
            context.ExceptionHandled = true;
        }

        base.OnException(context);
    }
}