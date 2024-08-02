using System.ComponentModel.DataAnnotations;
using MediatR;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;
using ValidationException = MovieLibraryServer.Domain.Exceptions.ValidationException;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class CreateMovieCommandHandler(
    IMovieRepository<Domain.Entities.Movie> movieRepository
) : IRequestHandler<CreateMovieCommand, MovieDto>
{
    public async Task<MovieDto> Handle(
        CreateMovieCommand request,
        CancellationToken cancellationToken
    )
    {
        var movie = new Domain.Entities.Movie
        {
            Title = request.MovieCreateDto.Title!,
            Director = request.MovieCreateDto.Director,
            Rate = request.MovieCreateDto.Rate,
            Year =
                request.MovieCreateDto.Year
                ?? throw new ValidationException(
                    new Dictionary<string, string[]>
                    {
                        { "Impossible things happened", ["You won million dollars"] }
                    }
                )
        };
        var retrievedMovie = await movieRepository.Create(movie);
        await movieRepository.SaveAsync();
        request.MovieCreateDto.Id = retrievedMovie.Id;

        return request.MovieCreateDto;
    }
}
