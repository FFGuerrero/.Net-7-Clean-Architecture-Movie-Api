using MediatR;
using MovieApi.Application.Common.Interfaces.Services;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Movies.Commands.UpdateMovie;
public record UpdateMovieCommand : IRequest
{
    public int Id { get; init; }
    public string Title { get; init; } = default!;
    public string? Description { get; init; }
    public int Stock { get; init; }
    public decimal RentalPrice { get; init; }
    public decimal SalePrice { get; init; }
    public bool Availability { get; init; }
}

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IMovieService _movieService;

    public UpdateMovieCommandHandler(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Id = request.Id,
            Title = request.Title.Trim(),
            Description = request.Description != null ? request.Description!.Trim() : null,
            Stock = request.Stock,
            RentalPrice = request.RentalPrice,
            SalePrice = request.SalePrice,
            Availability = request.Availability
        };

        return await _movieService.UpdateMovie(movie, cancellationToken);
    }
}