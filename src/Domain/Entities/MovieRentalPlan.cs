namespace MovieApi.Domain.Entities;
public class MovieRentalPlan : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int DurationInDays { get; set; }
    public decimal PenaltyAmount { get; set; }
    public bool IsAvailable { get; set; }

    public List<MovieRental>? MovieRentals { get; set; }
}