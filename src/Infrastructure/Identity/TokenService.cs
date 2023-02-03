using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Application.Common.Interfaces;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Infrastructure.Identity;
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IDateTime _dateTime;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(IConfiguration configuration,
        IDateTime dateTime,
        UserManager<ApplicationUser> userManager)
    {
        _configuration = configuration;
        _dateTime = dateTime;
        _userManager = userManager;
    }

    public async Task<(string token, DateTime expires)> GetTokenAsync(string userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var user = await _userManager.FindByNameAsync(userName);
        var roles = await _userManager.GetRolesAsync(user!);
        var now = _dateTime.Now;
        var issuedAtSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user!.Id),
            new (ClaimTypes.Name, userName!),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Iat, issuedAtSeconds.ToString(), ClaimValueTypes.Double),
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var jwt = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"]!,
            audience: _configuration["Jwt:Audience"]!,
            expires: now.AddMinutes(int.Parse(_configuration["Jwt:DurationInMinutes"]!)),
            claims: claims,
            notBefore: now,
            signingCredentials: creds
        );

        return (tokenHandler.WriteToken(jwt), jwt.ValidTo);
    }
}