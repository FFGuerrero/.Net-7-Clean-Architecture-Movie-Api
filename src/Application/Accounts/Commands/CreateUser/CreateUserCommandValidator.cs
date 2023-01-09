using FluentValidation;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Accounts.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IIdentityService _identityService;
    public CreateUserCommandValidator(IIdentityService identityService)
    {
        _identityService = identityService;
        RuleFor(v => v.UserName).NotEmpty()
            .MaximumLength(256)
            .MustAsync(BeUniqueUserName).WithMessage("The specified UserName already exists.");
        RuleFor(v => v.Password).NotEmpty()
            .MaximumLength(256);
        RuleFor(v => v.RoleName).NotEmpty()
            .MaximumLength(256)
            .MustAsync(RoleNameExists).WithMessage("The specified RoleName doesn't exist.");
    }

    public async Task<bool> BeUniqueUserName(string userName, CancellationToken cancellationToken)
    {
        return await _identityService.IsUniqueUserName(userName, cancellationToken);
    }

    public async Task<bool> RoleNameExists(string roleName, CancellationToken cancellationToken)
    {
        return await _identityService.RoleNameExists(roleName, cancellationToken);
    }
}