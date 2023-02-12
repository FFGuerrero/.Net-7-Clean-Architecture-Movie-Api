namespace MovieApi.Domain.Entities;
public class UserMovieLike : BaseAuditableEntity
{
    public int MovieId { get; set; }
    public string UserId { get; set; } = null!;

    public Movie? Movie { get; set; }
}