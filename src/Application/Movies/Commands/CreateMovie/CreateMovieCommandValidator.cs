using FluentValidation;

namespace MovieApi.Application.Movies.Commands.CreateMovie;
public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(v => v.Title).MaximumLength(50).NotEmpty();
        RuleFor(v => v.Description).MaximumLength(500);
        RuleFor(v => v.Stock).GreaterThanOrEqualTo(0);
        RuleFor(v => v.RentalPrice).GreaterThanOrEqualTo(0);
        RuleFor(v => v.SalePrice).GreaterThanOrEqualTo(0);
    }
}