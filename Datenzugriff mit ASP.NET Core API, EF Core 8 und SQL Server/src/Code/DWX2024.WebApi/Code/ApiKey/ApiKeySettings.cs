#nullable disable
namespace DWX2024.WebApi.Code.ApiKey;

/// <summary>
/// Settings for Api Key.
/// </summary>
public class ApiKeySettings
{
    /// <summary>
    /// The Api key or <c>null</c>. 
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Check if api key protection is avaiable.
    /// </summary>
    public bool ProtectWithApiKey => Key != null;
}
