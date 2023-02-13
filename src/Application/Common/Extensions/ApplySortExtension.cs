using System.Linq.Dynamic.Core;

namespace MovieApi.Application.Common.Extensions;
public static class ApplySortExtension
{
    public static IQueryable<T>? ApplySort<T>(this IQueryable<T>? entities, string? orderByProperty, bool isDescending)
    {
        if (entities is null || orderByProperty is null)
        {
            return entities;
        }

        if (!entities.Any())
        {
            return entities;
        }

        var sortingOrder = isDescending ? "descending" : "ascending";
        string fullColumnName = typeof(T).HasPropertyByName(orderByProperty).Item2!;

        return entities.OrderBy($"{fullColumnName} {sortingOrder}, id ascending");
    }
}