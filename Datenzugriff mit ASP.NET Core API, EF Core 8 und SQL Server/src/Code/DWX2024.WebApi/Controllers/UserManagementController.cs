using DWX2024.Infrastructure.DTOs;
using DWX2024.Infrastructure.Exceptions;
using DWX2024.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DWX2024.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserManagementController(IAppLogic appLogic,
                                          ILogger<UserManagementController> logger) : ControllerBase
    {
        private readonly IAppLogic appLogic = appLogic;
        private readonly ILogger<UserManagementController> logger = logger;

        /// <summary>
        /// (3) Fetch all users with permissions.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("AllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specific error. See details.", typeof(UserErrorDetails))]
        public async Task<ActionResult<IEnumerable<UserDto>>> FetchAllUsers(CancellationToken cancellationToken = default)
        {
            var result = await appLogic.FetchAllUsersAsync(cancellationToken);
            
            return Ok(result);
        }

        /// <summary>
        /// (4) Fetch one user.
        /// </summary>
        /// <param name="UNumber">User Id.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("User")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status404NotFound, "UNumber is invalid")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Specific error. See details.", typeof(UserErrorDetails))]
        public async Task<ActionResult<UserDto>> FetchSingleUser(string UNumber, CancellationToken cancellationToken)
        {
            var result = await appLogic.FetchSingleUserAsync(UNumber, cancellationToken);

            return Ok(result);
        }
    }
}