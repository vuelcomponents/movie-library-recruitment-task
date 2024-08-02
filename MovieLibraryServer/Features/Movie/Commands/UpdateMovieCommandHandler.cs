using MediatR;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Domain.Exceptions;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class UpdateMovieCommandHandler(
    IMovieRepository<Domain.Entities.Movie> movieRepository
) : IRequestHandler<UpdateMovieCommand, MovieDto>
{
    public async Task<MovieDto> Handle(
        UpdateMovieCommand request,
        CancellationToken cancellationToken
    )
    {
        var movie = await movieRepository.GetAsync(m => m.Id.Equals(request.MovieDto.Id));
        if (movie == null)
        {
            throw new MovieDoesNotExistException();
        }
        movie.Director = request.MovieDto.Director;
        movie.Rate = request.MovieDto.Rate;
        movie.Title = request.MovieDto.Title!;
        movie.Year =
            request.MovieDto.Year
            ?? throw new ValidationException(
                new Dictionary<string, string[]>
                {
                    { "Impossible things happened", ["You won million dollars"] }
                }
            );

        await movieRepository.SaveAsync();

        request.MovieDto.Id = movie.Id;
        return request.MovieDto;
    }
}
