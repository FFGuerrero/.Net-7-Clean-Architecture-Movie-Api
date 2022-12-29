using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
public record GetMoviesWithPaginationQuery : IRequest<PaginatedList<MovieDto>>
{
    public int MovieId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetMoviesWithPaginationQueryHandler : IRequestHandler<GetMoviesWithPaginationQuery, PaginatedList<MovieDto>>
{
    private readonly IMovieService _movieService;

    public GetMoviesWithPaginationQueryHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<PaginatedList<MovieDto>> Handle(GetMoviesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _movieService.GetMoviesWithPagination(request, cancellationToken);
    }
}