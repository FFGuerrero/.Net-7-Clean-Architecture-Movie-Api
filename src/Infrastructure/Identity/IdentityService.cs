using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Accounts.Commands.CreateUser;
using MovieApi.Application.Accounts.Commands.Login;
using MovieApi.Application.Common.Exceptions;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Models;

namespace MovieApi.Infrastructure.Identity;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly ITokenService _tokenService;
    private readonly ICurrentUserService _currentUserService;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService,
        ITokenService tokenService,
        ICurrentUserService currentUserService,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _tokenService = tokenService;
        _currentUserService = currentUserService;
        _signInManager = signInManager;
    }

    public async Task<string> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new ApplicationUser
        {
            UserName = createUserDto.UserName,
            Email = createUserDto.UserName,
            PhoneNumber = createUserDto.PhoneNumber,
            EmailConfirmed = false,
            PhoneNumberConfirmed = false,
        };

        var userResult = await _userManager.CreateAsync(user, createUserDto.Password);
        var result = userResult.ToApplicationResult();

        if (!result.Succeeded)
        {
            throw new IdentityValidationException(nameof(CreateUserDto.UserName), result.Errors.ToList());
        }

        var roleResult = await _userManager.AddToRoleAsync(user, createUserDto.RoleName);
        result = roleResult.ToApplicationResult();

        if (!result.Succeeded)
        {
            throw new IdentityValidationException(nameof(CreateUserDto.RoleName), result.Errors.ToList());
        }

        return user.Id;
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> CurrentUserIsInRoleAsync(string role)
    {
        var userId = _currentUserService.UserId ?? string.Empty;
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user is null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<LoginResponseDto> LoginUserAsync(string userName, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: true);

        if (result.IsLockedOut)
        {
            throw new LockedOutUserException(nameof(userName));
        }

        if (!result.Succeeded)
        {
            throw new InvalidUserCredentialsException($"{nameof(userName)}, {nameof(password)}");
        }

        var (token, expires) = await _tokenService.GetTokenAsync(userName);

        return new LoginResponseDto()
        {
            Token = token,
            Expires = expires
        };
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    public async Task<bool> IsUniqueUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userName);

        return user is null;
    }

    public async Task<bool> RoleNameExistsAsync(string roleName, CancellationToken cancellationToken)
    {
        return await _roleManager.RoleExistsAsync(roleName);
    }
}