using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Common.Interfaces.Services;
public interface IMovieService
{
    Task<PaginatedList<MovieDto>> GetMoviesWithPagination(GetMoviesWithPaginationQuery request, CancellationToken cancellationToken);
    Task<int> CreateMovie(Movie movie, CancellationToken cancellationToken);
    Task DeleteMovie(int id, CancellationToken cancellationToken);
    Task UpdateMovie(Movie movie, CancellationToken cancellationToken);
    Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken);
    Task<bool> IsUniqueTitleById(int id, string title, CancellationToken cancellationToken);
    Task<MovieDto> GetMovieById(int id, CancellationToken cancellationToken);
    Task SaleMovie(int movieId, CancellationToken cancellationToken);
    Task RentMovie(int movieId, int movieRentalPlanId, CancellationToken cancellationToken);
    Task ReturnMovie(int movieRentalId, CancellationToken cancellationToken);
    Task<bool> LikeMovieToggle(int movieId, CancellationToken cancellationToken);
}