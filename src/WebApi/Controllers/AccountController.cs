using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Accounts.Commands.ChangeRole;
using MovieApi.Application.Accounts.Commands.CreateUser;
using MovieApi.Application.Accounts.Commands.Login;
using MovieApi.WebApi.Controllers;

namespace WebApi.Controllers;

/// <summary>
/// Accounts API
/// </summary>
[Produces("application/json")]
public class AccountController : ApiControllerBase
{
    /// <summary>
    /// Adds a new user
    /// </summary>
    /// <param name="command">Command parameters</param>
    /// <returns>Created user Id</returns>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<string>> CreateUser(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Get new bearer token
    /// </summary>
    /// <param name="command">Command parameters</param>
    /// <returns>Bearer Token</returns>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> LoginUser(LoginCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Change role for existing user
    /// </summary>
    /// <param name="command">Command parameters</param>
    /// <returns>Change role result</returns>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Route("users/roles/change")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> ChangeUserRole(ChangeRoleCommand command)
    {
        await Mediator.Send(command);

        return NoContent();
    }
}