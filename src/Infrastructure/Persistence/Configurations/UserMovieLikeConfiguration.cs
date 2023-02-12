using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Configurations;
public class UserMovieLikeConfiguration : IEntityTypeConfiguration<UserMovieLike>
{
    public void Configure(EntityTypeBuilder<UserMovieLike> builder)
    {
        builder.Property(t => t.MovieId)
            .IsRequired();

        builder.Property(t => t.UserId)
            .IsRequired();

        builder.HasOne(e => e.Movie)
              .WithMany(b => b.UserMovieLikes)
              .HasForeignKey(e => e.MovieId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);
    }
}