using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Configurations;
public class MovieRentalPlanConfiguration : IEntityTypeConfiguration<MovieRentalPlan>
{
    public void Configure(EntityTypeBuilder<MovieRentalPlan> builder)
    {
        builder.Property(t => t.Name)
           .HasMaxLength(50)
           .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.DurationInDays);

        builder.Property(t => t.PenaltyAmount)
            .HasPrecision(10, 2);

        builder.Property(t => t.IsAvailable)
            .HasDefaultValue(false);
    }
}