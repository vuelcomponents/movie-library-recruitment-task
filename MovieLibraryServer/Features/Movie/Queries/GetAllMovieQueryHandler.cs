using MediatR;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;

namespace MovieLibraryServer.Features.Movie.Queries;

public sealed class GetAllMovieQueryHandler(IMovieRepository<Domain.Entities.Movie> movieRepository)
    : IRequestHandler<GetAllMovieQuery, List<MovieDto>>
{
    public async Task<List<MovieDto>> Handle(
        GetAllMovieQuery request,
        CancellationToken cancellationToken
    )
    {
        var movieStream = movieRepository.GetAllAsync();

        var movieDtos = await movieStream
            .SelectAwait(m =>
                ValueTask.FromResult(
                    new MovieDto
                    {
                        Director = m.Director,
                        Title = m.Title,
                        Id = m.Id,
                        Rate = m.Rate,
                        Year = m.Year
                    }
                )
            )
            .ToListAsync(cancellationToken);

        return movieDtos;
    }
}
