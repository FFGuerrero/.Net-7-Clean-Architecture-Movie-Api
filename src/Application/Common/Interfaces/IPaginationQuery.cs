namespace MovieApi.Application.Common.Interfaces;
public interface IPaginationQuery
{
    int PageNumber { get; init; }
    int PageSize { get; init; }
}