using MediatR;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Domain.Exceptions;
using MovieLibraryServer.Infrastructure.Clients;
using MovieLibraryServer.Infrastructure.Persistence.Repositories;

namespace MovieLibraryServer.Features.Movie.Commands;

public sealed class IntegrateMovieCommandHandler(
    ExternalMovieApiClient externalMovieApiClient,
    IMovieRepository movieRepository
) : IRequestHandler<IntegrateMovieCommand, List<MovieDto>>
{
    private static readonly object DbContextLock = new ();

    public async Task<List<MovieDto>> Handle(
        IntegrateMovieCommand request,
        CancellationToken cancellationToken
    )
    {
        List<MovieDto> downloadedMovies = await externalMovieApiClient.GetAsync<List<MovieDto>>(
            "/myMovies", 
            _ => throw new ExternalMovieLibraryRequestException()
            ,cancellationToken
        );

        List<MovieDto> newMovies = new List<MovieDto>();
        var tasks = new List<Task>();

        foreach (var dm in downloadedMovies)
        {
            if (dm.Title == null)
            {
                continue;
            }
            AllocateMovies(tasks, dm, newMovies, cancellationToken);
        }

        await Task.WhenAll(tasks);

        await movieRepository.SaveAsync(cancellationToken);

        return newMovies;
    }

    private void AllocateMovies(List<Task> tasks, MovieDto dm, List<MovieDto> newMovies, CancellationToken cancellationToken)
    {
        tasks.Add(
                Task.Run(
                    () =>
                    {
                        try
                        {
                            Domain.Entities.Movie? existingEntity;
                            lock (DbContextLock)
                            {
                                existingEntity = movieRepository
                                    .GetAsync(m => m.Title.Equals(dm.Title!), 
                                        null,
                                        cancellationToken
                                        )
                                    .Result;
                            }

                            if (existingEntity == null)
                            {
                                var newMovie = new Domain.Entities.Movie
                                {
                                    Title = dm.Title ?? "",
                                    Director = dm.Director,
                                    Rate = dm.Rate,
                                    Year = dm.Year ?? 2000
                                };

                                lock (DbContextLock)
                                {
                                    movieRepository.Create(newMovie, cancellationToken);
                                }

                                lock (newMovies)
                                {
                                    newMovies.Add(
                                        new MovieDto
                                        {
                                            Director = newMovie.Director,
                                            Title = newMovie.Title,
                                            Rate = newMovie.Rate,
                                            Year = newMovie.Year
                                        }
                                    );
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Houston, gotta problem: {ex.Message}");
                        }
                    },
                    cancellationToken
                )
            );
    }
}
