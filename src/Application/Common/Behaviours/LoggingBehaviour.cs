using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Common.Behaviours;
public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId ?? string.Empty;
        string userName = _currentUserService.UserName ?? string.Empty;

        await Task.Run(() => _logger.LogInformation("MovieApi Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request), cancellationToken);
    }
}