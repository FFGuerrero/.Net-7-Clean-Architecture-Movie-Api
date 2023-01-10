using MovieApi.Application.Accounts.Commands.CreateUser;
using MovieApi.Application.Accounts.Commands.Login;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Common.Interfaces.Services;
public interface IIdentityService
{
    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<string> CreateUserAsync(CreateUserDto createUserDto);

    Task<Result> DeleteUserAsync(string userId);
    Task<bool> IsUniqueUserNameAsync(string userName, CancellationToken cancellationToken);
    Task<bool> RoleNameExistsAsync(string roleName, CancellationToken cancellationToken);
    Task<LoginResponseDto> LoginUserAsync(string userName, string password);
}