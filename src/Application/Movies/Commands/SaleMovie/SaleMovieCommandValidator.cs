using FluentValidation;

namespace MovieApi.Application.Movies.Commands.SaleMovie;
public class SaleMovieCommandValidator : AbstractValidator<SaleMovieCommand>
{
    public SaleMovieCommandValidator()
    {
        RuleFor(v => v.MovieId).GreaterThan(0);
    }
}