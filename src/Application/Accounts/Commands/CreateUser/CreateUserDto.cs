namespace MovieApi.Application.Accounts.Commands.CreateUser;
public class CreateUserDto
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public string? PhoneNumber { get; set; }
}