using FluentValidation;

namespace MovieApi.Application.Movies.Commands.DeleteMovie;
public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(v => v.Id).GreaterThan(0);
    }
}