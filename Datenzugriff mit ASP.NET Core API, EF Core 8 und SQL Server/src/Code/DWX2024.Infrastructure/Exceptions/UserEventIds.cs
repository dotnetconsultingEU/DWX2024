using Microsoft.Extensions.Logging;

namespace DWX2024.Infrastructure.Exceptions;

public static class UserEventIds
{
    const int IDBASE = 700;

    public static readonly EventId NoProblem = new(IDBASE, "No Problem");
    public static readonly EventId NoPermissionsFound = new(IDBASE + 1, "No permissions found");
    public static readonly EventId NoUNumberSupplied1 = new(IDBASE + 2, "No uNumber supplied");
    public static readonly EventId NoUNumberSupplied2 = new(IDBASE + 3, "No uNumber supplied");
    public static readonly EventId NoUNumberSupplied3 = new(IDBASE + 4, "No uNumber supplied");
    public static readonly EventId InvalidPermission = new(IDBASE + 5, "Invalid permission");
    public static readonly EventId InvalidUserData = new(IDBASE + 6, "Invalid user data");
    public static readonly EventId NoUNumberSupplied4 = new(IDBASE + 7, "No uNumber supplied");
    public static readonly EventId InvalidPlant = new(IDBASE + 8, "Invalid plant");

}