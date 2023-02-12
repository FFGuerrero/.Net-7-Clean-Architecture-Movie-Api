using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Common.Models;
using MovieApi.Application.Movies.Commands.CreateMovie;
using MovieApi.Application.Movies.Commands.DeleteMovie;
using MovieApi.Application.Movies.Commands.LikeMovieToggle;
using MovieApi.Application.Movies.Commands.RentMovie;
using MovieApi.Application.Movies.Commands.ReturnMovie;
using MovieApi.Application.Movies.Commands.SaleMovie;
using MovieApi.Application.Movies.Commands.UpdateMovie;
using MovieApi.Application.Movies.Queries.GetMovieById;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.WebApi.Controllers;

namespace WebApi.Controllers;

/// <summary>
/// Movies API
/// </summary>
[Produces("application/json")]
[Authorize]
public class MoviesController : ApiControllerBase
{
    /// <summary>
    /// Get paginated list of Movies
    /// </summary>
    /// <param name="query">Query parameters</param>
    /// <returns>Paginated Movies</returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<PaginatedList<MovieDto>>> GetMoviesWithPagination([FromQuery] GetMoviesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// Get movie detail by Id
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns>Movie entity fetched by Id</returns>
    /// <response code="400">Validation error</response>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetMoviesById([FromRoute] int id)
    {
        return await Mediator.Send(new GetMovieByIdQuery() { Id = id });
    }

    /// <summary>
    /// Adds a new movie
    /// </summary>
    /// <param name="command">Command parameters</param>
    /// <returns>Created movie Id</returns>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<int>> CreateMovie(CreateMovieCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Delete a movie by Id
    /// </summary>
    /// <param name="id">Movie Id</param>
    /// <returns></returns>
    /// <response code="204">Success deleted</response>
    /// <response code="400">Validation error</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        await Mediator.Send(new DeleteMovieCommand(id));

        return NoContent();
    }

    /// <summary>
    /// Updates existing Movie
    /// </summary>
    /// <param name="id">Movie id</param>
    /// <param name="command">Command parameters</param>
    /// <returns></returns>
    /// <response code="204">Success updated</response>
    /// <response code="400">Validation error</response>
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> Update(int id, UpdateMovieCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Sell a movie
    /// </summary>
    /// <param name="movieId">Movie Id</param>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Route("{movieId}/sale")]
    [Authorize]
    public async Task<ActionResult> SaleMovie([FromRoute] int movieId)
    {
        await Mediator.Send(new SaleMovieCommand() { MovieId = movieId });

        return NoContent();
    }

    /// <summary>
    /// Rent a movie
    /// </summary>
    /// <param name="command">Command parameters</param>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Route("rent")]
    [Authorize]
    public async Task<ActionResult> RentMovie(RentMovieCommand command)
    {
        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Return a movie
    /// </summary>
    /// <param name="movieRentalId">Movie Rental Id</param>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Route("rentals/{movieRentalId}/return")]
    [Authorize]
    public async Task<ActionResult> ReturnMovie([FromRoute] int movieRentalId)
    {
        await Mediator.Send(new ReturnMovieCommand() { MovieRentalId = movieRentalId });

        return NoContent();
    }

    /// <summary>
    /// Add or remove like for a movie
    /// </summary>
    /// <param name="movieId">Movie Id</param>
    /// <response code="204">Success</response>
    /// <response code="400">Validation error</response>
    [HttpPost]
    [Route("{movieId}/like")]
    [Authorize]
    public async Task<ActionResult<bool>> LikeMovieToggle([FromRoute] int movieId)
    {
        return await Mediator.Send(new LikeMovieToggleCommand() { MovieId = movieId });
    }
}