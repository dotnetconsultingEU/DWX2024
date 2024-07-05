#nullable disable
namespace DWX2024.Infrastructure.Exceptions;

public class UserErrorDetails
{
    public int Id { get; set; }

    public string Message { get; set; }

    public object Details { get; set; }

    public static UserErrorDetails Create(UserException ex)
    {
        return new UserErrorDetails
        {
            Id = ex.EventId.Id,
            Message = ex.Message,
            Details = ex.Details
        };
    }

    public override string ToString() => $"{nameof(UserErrorDetails)}: {Id}";
}