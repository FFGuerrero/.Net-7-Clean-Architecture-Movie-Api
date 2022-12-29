using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.WebApi.Controllers;
using NSwag.Annotations;

namespace WebApi.Controllers;

[AllowAnonymous]
[Produces("application/json")]
[OpenApiTag("Movies", Description = "Movie API")]
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
        return Ok(await Mediator.Send(query));
    }
}