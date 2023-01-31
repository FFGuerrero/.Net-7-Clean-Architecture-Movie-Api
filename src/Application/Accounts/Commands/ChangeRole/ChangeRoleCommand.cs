using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Accounts.Commands.ChangeRole;
public class ChangeRoleCommand : IRequest<Result>
{
    public string UserName { get; init; } = default!;
    public string RoleName { get; init; } = default!;
}

public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand, Result>
{
    private readonly IIdentityService _identityService;

    public ChangeRoleCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var changeRoleDto = new ChangeRoleDto()
        {
            UserName = request.UserName,
            RoleName = request.RoleName,
            RemoveAllExistingRoles = true
        };

        var result = await _identityService.ChangeUserRoleAsync(changeRoleDto);
        return result;
    }
}