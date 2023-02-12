using MediatR;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Movies.Commands.RentMovie;
public record RentMovieCommand : IRequest
{
    public int MovieId { get; init; }
    public int MovieRentalPlanId { get; init; }
}

public class RentMovieCommandHandler : IRequestHandler<RentMovieCommand>
{
    private readonly IMovieService _movieService;

    public RentMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<Unit> Handle(RentMovieCommand request, CancellationToken cancellationToken)
    {
        await _movieService.RentMovie(request.MovieId, request.MovieRentalPlanId, cancellationToken);
        return Unit.Value;
    }
}