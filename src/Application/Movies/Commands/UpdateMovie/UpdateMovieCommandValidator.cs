using FluentValidation;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Movies.Commands.UpdateMovie;
public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    private readonly IMovieService _movieService;

    public UpdateMovieCommandValidator(IMovieService movieService)
    {
        _movieService = movieService;

        RuleFor(c => c.Id).NotNull().GreaterThan(0);
        RuleFor(v => v.Title).NotEmpty()
                             .MaximumLength(50)
                             .MustAsync(BeUniqueTitle).WithMessage("The specified movie title already exists.");
        RuleFor(v => v.Description).MaximumLength(500);
        RuleFor(v => v.Stock).GreaterThanOrEqualTo(0);
        RuleFor(v => v.RentalPrice).GreaterThanOrEqualTo(0);
        RuleFor(v => v.SalePrice).GreaterThanOrEqualTo(0);
    }

    public async Task<bool> BeUniqueTitle(UpdateMovieCommand model, string title, CancellationToken cancellationToken)
    {
        return await _movieService.IsUniqueTitleById(model.Id, title, cancellationToken);
    }
}