using MediatR;
using MovieApi.Application.Common.Interfaces;
using MovieApi.Application.Common.Models;

namespace MovieApi.Application.Common.Base;
public record BasePaginationQuery<TResponse> : IRequest<PaginatedList<TResponse>>, IPaginationQuery
    where TResponse : class
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}