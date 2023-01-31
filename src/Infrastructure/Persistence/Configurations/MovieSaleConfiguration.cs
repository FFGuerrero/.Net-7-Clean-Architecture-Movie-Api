using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Configurations;
public class MovieSaleConfiguration : IEntityTypeConfiguration<MovieSale>
{
    public void Configure(EntityTypeBuilder<MovieSale> builder)
    {
        builder.Property(t => t.MovieId)
            .IsRequired();

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.Property(t => t.Price)
            .HasPrecision(10, 2);

        builder.HasOne(e => e.Movie)
              .WithMany(b => b.MovieSales)
              .HasForeignKey(e => e.MovieId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);
    }
}