using FluentValidation;

namespace MovieApi.Application.Accounts.Commands.Login;
public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(v => v.UserName).NotEmpty().MaximumLength(256);
        RuleFor(v => v.Password).NotEmpty().MaximumLength(256);
    }
}