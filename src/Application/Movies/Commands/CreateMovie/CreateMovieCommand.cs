using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Movies.Commands.CreateMovie;
public record CreateMovieCommand : IRequest<int>
{
    public string Title { get; init; } = default!;
    public string? Description { get; init; }
    public int Stock { get; init; }
    public decimal RentalPrice { get; init; }
    public decimal SalePrice { get; init; }
    public bool Availability { get; init; }
}

public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IMovieService _movieService;

    public CreateMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Title = request.Title,
            Description = request.Description,
            Stock = request.Stock,
            RentalPrice = request.RentalPrice,
            SalePrice = request.SalePrice,
            Availability = request.Availability
        };

        return await _movieService.CreateMovie(movie, cancellationToken);
    }
}