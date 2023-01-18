using System.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Common.Exceptions;
using MovieApi.Application.Common.Interfaces;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Mappings;
using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.Domain.Entities;
using MovieApi.Domain.Enums;

namespace MovieApi.Infrastructure.Persistence.Services;
public class MovieService : IMovieService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public MovieService(IApplicationDbContext context, IMapper mapper, IIdentityService identityService)
    {
        _context = context;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<PaginatedList<MovieDto>> GetMoviesWithPagination(GetMoviesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var movies = _context.Movies.AsQueryable();
        var userIsInAdminRole = await _identityService.CurrentUserIsInRoleAsync(Role.Administrator);

        if (!userIsInAdminRole)
        {
            movies = movies.Where(x => x.IsAvailableForRental || x.IsAvailableForSale);
        }

        if (request.Title is not null)
        {
            movies = movies.Where(x => x.Title.Contains(request.Title));
        }

        return await movies.OrderBy(x => x.Title)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }

    public async Task<int> CreateMovie(Movie movie, CancellationToken cancellationToken)
    {
        await _context.Movies.AddAsync(movie, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }

    public async Task<Unit> DeleteMovie(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies.FindAsync(new object[] { id }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(Movie), id);
        }

        _context.Movies.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<Unit> UpdateMovie(Movie movie, CancellationToken cancellationToken)
    {
        var entity = await _context.Movies.FindAsync(new object[] { movie.Id }, cancellationToken);
        if (entity is null)
        {
            throw new NotFoundException(nameof(Movie), movie.Id);
        }

        entity.Title = movie.Title;
        entity.Description = movie.Description;
        entity.Stock = movie.Stock;
        entity.RentalPrice = movie.RentalPrice;
        entity.SalePrice = movie.SalePrice;
        entity.IsAvailableForRental = movie.IsAvailableForRental;
        entity.IsAvailableForSale = movie.IsAvailableForSale;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    public async Task<bool> IsUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .AllAsync(l => l.Title != title, cancellationToken);
    }

    public async Task<bool> IsUniqueTitleById(int id, string title, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .Where(l => l.Id != id)
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}