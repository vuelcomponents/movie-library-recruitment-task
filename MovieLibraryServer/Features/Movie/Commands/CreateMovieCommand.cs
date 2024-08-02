using MediatR;
using MovieLibraryServer.Domain.Dto;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class CreateMovieCommand(MovieDto movieCreateDto) : IRequest<MovieDto>
{
    public MovieDto MovieCreateDto { get; set; } = movieCreateDto;
}
