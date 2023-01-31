using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;

namespace MovieApi.Application.Movies.Queries.GetMovieById;
public record GetMovieByIdQuery : IRequest<MovieDto>
{
    public int Id { get; set; }
}

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDto>
{
    protected readonly IMovieService _movieService;

    public GetMovieByIdQueryHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<MovieDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _movieService.GetMovieById(request.Id, cancellationToken);
    }
}