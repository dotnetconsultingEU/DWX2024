using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DWX2024.WebApi.Code.ApiKey;


/// <summary>
/// Filter to check api key.
/// </summary>
public class ApiKeyFilter(ApiKeySettings Settings) : IAuthorizationFilter
{
    /// <summary>
    /// Name of header.
    /// </summary>
    public const string APIKEYNAME = "x-api-key";

    /// <summary>
    /// The key od <c>null</c>.
    /// </summary>
    private readonly string _apiKey = Settings?.Key!;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        bool skipApiKeyCheck = false;

        // Currently we only skip the check if the Info-Controller is invoked.
        if (context.ActionDescriptor is ControllerActionDescriptor cad)
        {
            // Skip for Info-Controller
            // skipApiKeyCheck = cad.ControllerTypeInfo.AsType() == typeof(InfoController);
        }

        if (skipApiKeyCheck)
            return;

        // Verify API key
        string apiKey = context.HttpContext.Request.Headers[APIKEYNAME].ToString();

        if (string.Compare(_apiKey, apiKey) != 0)
            context.Result = new UnauthorizedResult();
    }
}
