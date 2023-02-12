using MovieApi.Application.Common.Mappings;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Stock { get; set; }
    public decimal RentalPrice { get; set; }
    public decimal SalePrice { get; set; }
    public bool IsAvailableForRental { get; set; }
    public bool IsAvailableForSale { get; set; }
    public int Likes { get; set; }
}