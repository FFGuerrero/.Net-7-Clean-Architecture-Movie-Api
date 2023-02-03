namespace MovieApi.Domain.Entities;
public class MovieRental : BaseAuditableEntity
{
    public int MovieId { get; set; }
    public string UserId { get; set; } = null!;
    public int MovieRentalPlanId { get; set; }
    public decimal Price { get; set; }
    public DateTime? RentDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal PenaltyAmount { get; set; }

    public Movie? Movie { get; set; }
    public MovieRentalPlan? MovieRentalPlan { get; set; }
}