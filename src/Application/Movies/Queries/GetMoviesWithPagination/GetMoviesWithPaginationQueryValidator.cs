using FluentValidation;
using MovieApi.Application.Common.Base;

namespace MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
public class GetMoviesWithPaginationQueryValidator : AbstractValidator<GetMoviesWithPaginationQuery>
{
    public GetMoviesWithPaginationQueryValidator()
    {
        Include(new BasePaginationQueryValidator<MovieDto>());
    }
}