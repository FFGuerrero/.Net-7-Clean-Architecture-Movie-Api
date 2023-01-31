namespace MovieApi.Domain.Entities;

public class MovieSale : BaseAuditableEntity
{
    public int MovieId { get; set; }
    public string UserId { get; set; } = null!;
    public decimal Price { get; set; }

    public Movie? Movie { get; set; }
}