using MediatR;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Movies.Commands.LikeMovieToggle;
public class LikeMovieToggleCommand : IRequest<bool>
{
    public int MovieId { get; init; }
}

public class LikeMovieCommandHandler : IRequestHandler<LikeMovieToggleCommand, bool>
{
    private readonly IMovieService _movieService;

    public LikeMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<bool> Handle(LikeMovieToggleCommand request, CancellationToken cancellationToken)
    {
        var result = await _movieService.LikeMovieToggle(request.MovieId, cancellationToken);
        return result;
    }
}