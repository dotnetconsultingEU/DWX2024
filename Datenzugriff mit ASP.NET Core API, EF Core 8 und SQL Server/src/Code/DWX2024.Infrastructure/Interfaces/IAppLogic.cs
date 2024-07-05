using DWX2024.Infrastructure.DTOs;

namespace DWX2024.Infrastructure.Interfaces;

public interface IAppLogic
{
    Task<IEnumerable<UserDto>> FetchAllUsersAsync(CancellationToken cancellationToken = default);
    Task<UserDto> FetchSingleUserAsync(string UNumber, CancellationToken cancellationToken);

}