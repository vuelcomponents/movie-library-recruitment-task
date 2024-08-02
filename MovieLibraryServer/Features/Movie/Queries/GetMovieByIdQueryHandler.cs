using MediatR;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Domain.Exceptions;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;

namespace MovieLibraryServer.Features.Movie.Queries;

public sealed class GetMovieByIdQueryHandler(
    IMovieRepository movieRepository
) : IRequestHandler<GetMovieByIdQuery, MovieDto>
{
    public async Task<MovieDto> Handle(
        GetMovieByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var movie = await movieRepository.GetAsync(m => m.Id.Equals(request.Id), null, cancellationToken);
        if (movie == null)
        {
            throw new MovieDoesNotExistException();
        }
        return new MovieDto
        {
            Id = movie.Id,
            Director = movie.Director,
            Title = movie.Title,
            Rate = movie.Rate,
            Year = movie.Year
        };
    }
}
