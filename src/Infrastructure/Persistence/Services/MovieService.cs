using System.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MovieApi.Application.Common.Interfaces;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Application.Common.Mappings;
using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.Domain.Entities;

namespace MovieApi.Infrastructure.Persistence.Services;
public class MovieService : IMovieService
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MovieService(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<MovieDto>> GetMoviesWithPagination(GetMoviesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Movies
            .OrderBy(x => x.Title)
            .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }

    public async Task<int> CreateMovie(Movie movie, CancellationToken cancellationToken)
    {
        await _context.Movies.AddAsync(movie, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
