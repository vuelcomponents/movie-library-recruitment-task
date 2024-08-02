using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Features.Movie.Commands;
using MovieLibraryServer.Features.Movie.Queries;
using MovieLibraryServer.Web.Controllers.Base;

namespace MovieLibraryServer.Web.Controllers;

[Route("api/movie")]
public sealed class MovieController(IMediator mediator)
    : BaseCrudController<
        MovieDto,
        CreateMovieCommand,
        UpdateMovieCommand,
        DeleteManyMovieCommand,
        GetMovieByIdQuery,
        GetAllMovieQuery
    >(mediator)
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("integrate")]
    public async Task<ActionResult<List<MovieDto>>> Integrate()
    {
        var query = new IntegrateMovieCommand();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}