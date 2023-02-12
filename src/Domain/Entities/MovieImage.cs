namespace MovieApi.Domain.Entities;
public class MovieImage : BaseAuditableEntity
{
    public int MovieId { get; set; }
    public string ImageUrl { get; set; } = null!;

    public Movie? Movie { get; set; }
}