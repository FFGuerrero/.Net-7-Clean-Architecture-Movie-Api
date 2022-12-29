using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.WebApi.Controllers;

namespace WebApi.Controllers;

/// <summary>
/// Movies API
/// </summary>
[AllowAnonymous]
[Produces("application/json")]
public class MoviesController : ApiControllerBase
{
    /// <summary>
    /// Get paginated list of Movies
    /// </summary>
    /// <param name="query">Query parameters</param>
    /// <returns>Paginated Movies</returns>
    [HttpGet]
    public async Task<ActionResult<PaginatedList<MovieDto>>> GetMoviesWithPagination([FromQuery] GetMoviesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}