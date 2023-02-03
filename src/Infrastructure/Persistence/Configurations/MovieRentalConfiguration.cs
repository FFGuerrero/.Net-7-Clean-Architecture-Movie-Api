using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Configurations;
public class MovieRentalConfiguration : IEntityTypeConfiguration<MovieRental>
{
    public void Configure(EntityTypeBuilder<MovieRental> builder)
    {
        builder.Property(t => t.MovieId)
            .IsRequired();

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.MovieRentalPlanId)
            .IsRequired();

        builder.Property(t => t.Price)
            .HasPrecision(10, 2);

        builder.Property(t => t.RentDate)
            .IsRequired();

        builder.Property(t => t.ReturnDate);

        builder.Property(t => t.PenaltyAmount)
            .HasPrecision(10, 2);

        builder.HasOne(e => e.Movie)
              .WithMany(b => b.MovieRentals)
              .HasForeignKey(e => e.MovieId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.MovieRentalPlan)
              .WithMany(b => b.MovieRentals)
              .HasForeignKey(e => e.MovieRentalPlanId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);
    }
}