using MediatR;
using MovieLibraryServer.Domain.Dto;

namespace MovieLibraryServer.Features.Movie.Queries;

public sealed class GetMovieByIdQuery(long id) : IRequest<MovieDto>
{
    public long Id { get; set; } = id;
}
