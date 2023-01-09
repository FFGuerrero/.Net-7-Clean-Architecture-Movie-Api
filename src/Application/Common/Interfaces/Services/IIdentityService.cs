using MovieApi.Application.Accounts.Commands.CreateUser;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Common.Interfaces.Services;
public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<string> CreateUserAsync(CreateUserDto createUserDto);

    Task<Result> DeleteUserAsync(string userId);
    Task<bool> IsUniqueUserName(string userName, CancellationToken cancellationToken);
    Task<bool> RoleNameExists(string roleName, CancellationToken cancellationToken);
}