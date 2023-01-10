using Microsoft.AspNetCore.Identity;

namespace MovieApi.Infrastructure.Identity;
public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
}