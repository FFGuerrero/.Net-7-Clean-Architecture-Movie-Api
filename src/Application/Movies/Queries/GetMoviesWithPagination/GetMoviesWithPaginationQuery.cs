using MediatR;
using MovieApi.Application.Common.Base;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
public record GetMoviesWithPaginationQuery : BasePaginationQuery<MovieDto>
{
    public int MovieId { get; init; }
    public string? Title { get; init; }
    public bool? IsAvailableForRental { get; init; }
    public bool? IsAvailableForSale { get; init; }
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
        request.OrderBy ??= nameof(MovieDto.Title);
        return await _movieService.GetMoviesWithPagination(request, cancellationToken);
    }
}