using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Accounts.Commands.ChangeRole;
public class ChangeRoleCommand : IRequest
{
    public string UserName { get; init; } = default!;
    public string RoleName { get; init; } = default!;
}

public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand>
{
    private readonly IIdentityService _identityService;

    public ChangeRoleCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Unit> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var changeRoleDto = new ChangeRoleDto()
        {
            UserName = request.UserName,
            RoleName = request.RoleName,
            RemoveAllExistingRoles = true
        };

        await _identityService.ChangeUserRoleAsync(changeRoleDto);
        return Unit.Value;
    }
}