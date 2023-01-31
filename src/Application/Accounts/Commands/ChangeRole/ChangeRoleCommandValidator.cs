using FluentValidation;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Accounts.Commands.ChangeRole;
public class ChangeRoleCommandValidator : AbstractValidator<ChangeRoleCommand>
{
    private readonly IIdentityService _identityService;
    public ChangeRoleCommandValidator(IIdentityService identityService)
    {
        _identityService = identityService;
        RuleFor(v => v.UserName).NotEmpty()
            .MaximumLength(256)
            .MustAsync(UserNameExists).WithMessage("The specified UserName doesn't exists.");
        RuleFor(v => v.RoleName).NotEmpty()
            .MaximumLength(256)
            .MustAsync(RoleNameExists).WithMessage("The specified RoleName doesn't exist.");
    }

    public async Task<bool> UserNameExists(string userName, CancellationToken cancellationToken)
    {
        return await _identityService.UserNameExistsAsync(userName, cancellationToken);
    }

    public async Task<bool> RoleNameExists(string roleName, CancellationToken cancellationToken)
    {
        return await _identityService.RoleNameExistsAsync(roleName, cancellationToken);
    }
}