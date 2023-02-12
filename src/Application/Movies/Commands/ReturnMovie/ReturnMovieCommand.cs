using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Movies.Commands.RentMovie;

namespace MovieApi.Application.Movies.Commands.ReturnMovie;
public record ReturnMovieCommand : IRequest
{
    public int MovieRentalId { get; set; }
}

public class ReturnMovieCommandHandler : IRequestHandler<ReturnMovieCommand>
{
    private readonly IMovieService _movieService;

    public ReturnMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<Unit> Handle(ReturnMovieCommand request, CancellationToken cancellationToken)
    {
        await _movieService.ReturnMovie(request.MovieRentalId, cancellationToken);
        return Unit.Value;
    }
}