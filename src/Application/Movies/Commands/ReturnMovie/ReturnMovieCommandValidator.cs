using FluentValidation;

namespace MovieApi.Application.Movies.Commands.ReturnMovie;
public class ReturnMovieCommandValidator : AbstractValidator<ReturnMovieCommand>
{
    public ReturnMovieCommandValidator()
    {
        RuleFor(v => v.MovieRentalId).GreaterThan(0);
    }
}