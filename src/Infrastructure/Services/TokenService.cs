using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Application.Common.Interfaces;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Infrastructure.Services;
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IDateTime _dateTime;
    public TokenService(IConfiguration configuration, IDateTime dateTime)
    {
        _configuration = configuration;
        _dateTime = dateTime;
    }

    public (string token, DateTime expires) CreateJwtToken(List<Claim> additionalClaims)
    {
        var now = _dateTime.Now;
        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString()),
        };
        claims.AddRange(additionalClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var jwt = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"]!,
            audience: _configuration["Jwt:Audience"]!,
            expires: now.AddMinutes(int.Parse(_configuration["Jwt:DurationInMinutes"]!)),
            claims: claims,
            notBefore: now,
            signingCredentials: creds
        );

        return (new JwtSecurityTokenHandler().WriteToken(jwt), jwt.ValidTo);
    }
}