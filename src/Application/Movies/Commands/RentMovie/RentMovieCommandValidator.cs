using FluentValidation;

namespace MovieApi.Application.Movies.Commands.RentMovie;
public class RentMovieCommandValidator : AbstractValidator<RentMovieCommand>
{
    public RentMovieCommandValidator()
    {
        RuleFor(v => v.MovieId).GreaterThan(0);
        RuleFor(v => v.MovieRentalPlanId).GreaterThan(0);
    }
}