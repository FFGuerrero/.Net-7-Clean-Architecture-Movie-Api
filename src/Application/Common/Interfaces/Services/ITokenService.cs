using System.Security.Claims;

namespace MovieApi.Application.Common.Interfaces.Services;
public interface ITokenService
{
    (string token, DateTime expires) CreateJwtToken(List<Claim> additionalClaims);
}