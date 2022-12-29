using MovieApi.Application.Common.Mappings;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
public class MovieDto : IMapFrom<Movie>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Stock { get; set; }
    public decimal RentalPrice { get; set; }
    public decimal SalePrice { get; set; }
    public bool Availability { get; set; }
}