using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Accounts.Commands.CreateUser;
using MovieApi.WebApi.Controllers;

namespace WebApi.Controllers;

/// <summary>
/// Accounts API
/// </summary>
[Produces("application/json")]
[AllowAnonymous]
public class AccountController : ApiControllerBase
{
    /// <summary>
    /// Adds a new user
    /// </summary>
    /// <param name="command">Command parameters</param>
    /// <returns>Created user Id</returns>
    [HttpPost]
    public async Task<ActionResult<string>> CreateUser(CreateUserCommand command)
    {
        return await Mediator.Send(command);
    }
}