using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Configurations;
public class MovieImageConfiguration : IEntityTypeConfiguration<MovieImage>
{
    public void Configure(EntityTypeBuilder<MovieImage> builder)
    {
        builder.Property(t => t.MovieId)
            .IsRequired();

        builder.Property(t => t.ImageUrl)
            .HasMaxLength(512)
            .IsRequired();

        builder.HasOne(e => e.Movie)
              .WithMany(b => b.MovieImages)
              .HasForeignKey(e => e.MovieId)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);
    }
}