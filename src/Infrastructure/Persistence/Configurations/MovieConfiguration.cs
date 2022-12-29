using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Configurations;
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(500);

        builder.Property(t => t.RentalPrice)
            .HasPrecision(10, 2);

        builder.Property(t => t.SalePrice)
            .HasPrecision(10, 2);

        builder.Property(t => t.Availability)
            .HasDefaultValue(false);
    }
}