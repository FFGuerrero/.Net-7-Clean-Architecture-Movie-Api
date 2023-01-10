using MediatR;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Accounts.Commands.Login;
public record LoginCommand : IRequest<LoginResponseDto>
{
    public string UserName { get; init; } = default!;
    public string Password { get; init; } = default!;
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly IIdentityService _identityService;
    public LoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.LoginUserAsync(request.UserName, request.Password);
    }
}