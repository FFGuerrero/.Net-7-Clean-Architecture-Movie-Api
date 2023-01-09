using MediatR;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Accounts.Commands.CreateUser;
public record CreateUserCommand : IRequest<string>
{
    public string UserName { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string RoleName { get; init; } = default!;
    public string? PhoneNumber { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IIdentityService _identityService;

    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var createUserDto = new CreateUserDto()
        {
            UserName = request.UserName,
            Password = request.Password,
            RoleName = request.RoleName,
            PhoneNumber = request.PhoneNumber
        };

        var result = await _identityService.CreateUserAsync(createUserDto);
        return result;
    }
}