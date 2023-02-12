using FluentValidation;

namespace MovieApi.Application.Movies.Commands.LikeMovieToggle;
public class LikeMovieToggleCommandValidator : AbstractValidator<LikeMovieToggleCommand>
{
    public LikeMovieToggleCommandValidator()
    {
        RuleFor(v => v.MovieId).GreaterThan(0);
    }
}