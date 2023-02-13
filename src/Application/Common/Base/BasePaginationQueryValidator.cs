using FluentValidation;
using MovieApi.Application.Common.Extensions;
using MovieApi.Application.Common.Interfaces;

namespace MovieApi.Application.Common.Base;
public class BasePaginationQueryValidator<TResponse> : AbstractValidator<IPaginationQuery>
{
    public BasePaginationQueryValidator()
    {
        RuleFor(x => x.OrderBy)
            .MustAsync(IsValidColumn)
            .When(x => x.OrderBy is not null)
            .WithMessage("This column name for OrderBy doesn't exists");

        RuleFor(x => x.IsDescending)
            .NotNull();

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }

    private async Task<bool> IsValidColumn(string? value, CancellationToken cancel)
    {
        var result = await Task.FromResult(typeof(TResponse).HasPropertyByName(value!));
        return result.Item1;
    }
}