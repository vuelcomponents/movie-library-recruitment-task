using MediatR;
using MovieLibraryServer.Domain.Dto;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class UpdateMovieCommand(MovieDto movieUpdateDto) : IRequest<MovieDto>
{
    public MovieDto MovieDto { get; set; } = movieUpdateDto;
}
