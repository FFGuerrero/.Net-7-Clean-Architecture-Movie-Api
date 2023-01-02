using MediatR;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Movies.Commands.DeleteMovie;
public record DeleteMovieCommand(int Id) : IRequest;

public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IMovieService _movieService;

    public DeleteMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        return await _movieService.DeleteMovie(request.Id, cancellationToken);
    }
}