using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Movie> Movies { get; }

    DbSet<MovieSale> MovieSales { get; }

    DbSet<MovieRental> MovieRentals { get; }

    DbSet<MovieRentalPlan> MovieRentalPlans { get; }

    DbSet<UserMovieLike> UserMovieLikes { get; }

    DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}