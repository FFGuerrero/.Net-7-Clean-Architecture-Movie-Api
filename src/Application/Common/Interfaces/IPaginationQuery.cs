namespace MovieApi.Application.Common.Interfaces;
public interface IPaginationQuery
{
    string? OrderBy { get; set; }
    bool IsDescending { get; init; }
    int PageNumber { get; init; }
    int PageSize { get; init; }
}