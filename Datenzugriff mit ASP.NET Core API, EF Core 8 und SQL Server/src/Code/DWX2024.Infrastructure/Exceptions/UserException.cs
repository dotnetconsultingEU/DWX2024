using Microsoft.Extensions.Logging;

namespace DWX2024.Infrastructure.Exceptions;

public class UserException(EventId EventId, object Details) : Exception($"EventId={EventId.Id} ({EventId.Name}) was thrown")
{
    public readonly EventId EventId = EventId;
    public readonly object Details = Details!;

    public UserException(EventId EventId) : this(EventId, null!)
    {
    }
}