using MediatR;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Movies.Commands.SaleMovie;
public record SaleMovieCommand : IRequest
{
    public int MovieId { get; set; }
}

public class SaleMovieCommandHandler : IRequestHandler<SaleMovieCommand>
{
    private readonly IMovieService _movieService;

    public SaleMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<Unit> Handle(SaleMovieCommand request, CancellationToken cancellationToken)
    {
        await _movieService.SaleMovie(request.MovieId, cancellationToken);
        return Unit.Value;
    }
}