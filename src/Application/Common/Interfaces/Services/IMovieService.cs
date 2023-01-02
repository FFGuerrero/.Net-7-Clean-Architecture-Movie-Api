using MediatR;
using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Common.Interfaces.Services;
public interface IMovieService
{
    Task<PaginatedList<MovieDto>> GetMoviesWithPagination(GetMoviesWithPaginationQuery request, CancellationToken cancellationToken);
    Task<int> CreateMovie(Movie movie, CancellationToken cancellationToken);
    Task<Unit> DeleteMovie(int id, CancellationToken cancellationToken);
}