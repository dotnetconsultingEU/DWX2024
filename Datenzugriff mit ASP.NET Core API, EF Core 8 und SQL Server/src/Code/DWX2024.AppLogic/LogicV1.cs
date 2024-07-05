using DWX2024.Infrastructure.DTOs;
using DWX2024.Infrastructure.Interfaces;

namespace DWX2024.AppLogic;

public class LogicV1 : IAppLogic
{
    public Task<IEnumerable<UserDto>> FetchAllUsersAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}