namespace MovieApi.Application.Common.Interfaces.Services;
public interface ITokenService
{
    Task<(string token, DateTime expires)> GetTokenAsync(string userName);
}