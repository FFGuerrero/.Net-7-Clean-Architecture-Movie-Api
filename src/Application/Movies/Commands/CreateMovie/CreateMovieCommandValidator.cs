using FluentValidation;
using MovieApi.Application.Common.Interfaces.Services;

namespace MovieApi.Application.Movies.Commands.CreateMovie;
public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    private readonly IMovieService _movieService;

    public CreateMovieCommandValidator(IMovieService movieService)
    {
        _movieService = movieService;

        RuleFor(v => v.Title).NotEmpty()
                             .MaximumLength(50)
                             .MustAsync(BeUniqueTitle).WithMessage("The specified movie title already exists.");
        RuleFor(v => v.Description).MaximumLength(500);
        RuleFor(v => v.Stock).GreaterThanOrEqualTo(0);
        RuleFor(v => v.RentalPrice).GreaterThanOrEqualTo(0);
        RuleFor(v => v.SalePrice).GreaterThanOrEqualTo(0);
        RuleFor(v => v.MovieImages).Must(BeValidUri)
            .WithMessage("You must enter at least one valid image URL");
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _movieService.IsUniqueTitle(title, cancellationToken);
    }

    public static bool BeValidUri(List<string>? userImages)
    {
        if (userImages is null)
        {
            return false;
        }

        if (userImages.Count == 0)
        {
            return false;
        }

        foreach (var uri in userImages)
        {
            if (!Uri.TryCreate(uri, UriKind.Absolute, out _))
            {
                return false;
            }
        }

        return true;
    }
}