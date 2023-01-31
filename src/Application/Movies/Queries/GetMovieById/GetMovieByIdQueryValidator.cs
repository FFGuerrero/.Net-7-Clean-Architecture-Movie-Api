using FluentValidation;

namespace MovieApi.Application.Movies.Queries.GetMovieById;
public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
{
    public GetMovieByIdQueryValidator()
    {
        RuleFor(c => c.Id).NotNull().GreaterThan(0);
    }
}