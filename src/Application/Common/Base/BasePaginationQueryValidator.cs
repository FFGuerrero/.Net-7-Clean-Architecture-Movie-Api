using FluentValidation;
using MovieApi.Application.Common.Interfaces;

namespace MovieApi.Application.Common.Base;
public class BasePaginationQueryValidator : AbstractValidator<IPaginationQuery>
{
    public BasePaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}