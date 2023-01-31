namespace MovieApi.Application.Accounts.Commands.ChangeRole;
public class ChangeRoleDto
{
    public string UserName { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public bool RemoveAllExistingRoles { get; set; }
}