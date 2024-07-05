using DWX2024.AppLogic.EntityFramework;
using DWX2024.Infrastructure.DTOs;
using DWX2024.Infrastructure.Exceptions;
using DWX2024.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace DWX2024.AppLogic;

public class LogicV1(dncUserDatabaseContext dncUserDatabaseContext,
                     ILogger<LogicV1> logger) : IAppLogic
{
    private readonly dncUserDatabaseContext dncUserDatabaseContext = dncUserDatabaseContext;
    private readonly ILogger<LogicV1> logger = logger;

    public async Task<IEnumerable<UserDto>> FetchAllUsersAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("FetchAllUsersAsync()");

        try
        {
            var rawResult = await dncUserDatabaseContext.Users.Include(i => i.UserRoles)
                                        .Include(i => i.UserPlantCodes)
                                        .AsNoTracking()
                                        .OrderBy(o => o.Name)
                                        .ToListAsync(cancellationToken);


            var result = rawResult.Select(s => new UserDto(UNumber: s.Name,
                                                            Username: s.Name,
                                                            Firstname: s.FirstName,
                                                            Lastname: s.LastName,
                                                            Email: s.Email,
                                                            Culture: s.ResourceId,
                                                            Plants: s.UserPlantCodes.Select(s => new PlantDto(s.PlantCode)),
                                                            Status: "active",
                                                            Permissions: s.UserRoles.Select(s => new PermissionDto("Dummy"))
                        ));

            return result;
        }
        catch (TaskCanceledException)
        {
            // Nur Abbruch des Tasks
            return null!;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (UserException)
        {
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Can't fetch available users");
            throw;
        }
    }

    public async Task<UserDto> FetchSingleUserAsync(string UNumber, CancellationToken cancellationToken)
    {
        logger.LogInformation("FetchSingleUserAsync({UNumber})", UNumber);

        try
        {
            if (string.IsNullOrWhiteSpace(UNumber))
                throw new UserException(UserEventIds.NoUNumberSupplied1);

            var rawResult = await dncUserDatabaseContext.Users.Include(i => i.UserRoles)
                                                  .Include(i => i.UserPlantCodes)
                                                  .AsNoTracking()
                                                  .FirstOrDefaultAsync(w => w.Name == UNumber, cancellationToken);

            if (rawResult is not null)
            {
                return new UserDto(UNumber: rawResult.Name,
                                   Username: rawResult.Name,
                                   Firstname: rawResult.FirstName,
                                   Lastname: rawResult.LastName,
                                   Email: rawResult.Email,
                                   Culture: rawResult.ResourceId,
                                   Status: "active",
                                   Plants: rawResult.UserPlantCodes.Select(s => new PlantDto(s.PlantCode)),
                                   Permissions: rawResult.UserRoles.Select(s => new PermissionDto("Dummy"))
                    );
            }
            else
                throw new ArgumentOutOfRangeException(nameof(UNumber));
        }
        catch (TaskCanceledException)
        {
            // Nur Abbruch des Tasks
            return null!;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (UserException)
        {
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Can't fetch available permissions");
            throw;
        }
    }

}