namespace MovieApi.Domain.Entities;

public class Movie : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public int Stock { get; set; }
    public decimal RentalPrice { get; set; }
    public decimal SalePrice { get; set; }
    public bool IsAvailableForRental { get; set; }
    public bool IsAvailableForSale { get; set; }

    public List<MovieSale>? MovieSales { get; set; }
}