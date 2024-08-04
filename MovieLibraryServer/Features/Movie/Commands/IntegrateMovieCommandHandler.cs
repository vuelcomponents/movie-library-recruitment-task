using System.Collections.Frozen;
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
         
        FrozenDictionary<string, MovieDto> movieDictionary = downloadedMovies
            .Where(dm => dm.Title != null) 
            .ToFrozenDictionary(dm => dm.Title!, dm => dm);
        
        HashSet<string> newMovies = new ();
        
        var tasks = new List<Task>();

        foreach (var kvp in movieDictionary)
        {
            AllocateMovies(tasks, kvp.Value, newMovies, cancellationToken);
        }

        await Task.WhenAll(tasks);

        await movieRepository.SaveAsync(cancellationToken);

        List<Domain.Entities.Movie> dbMovies = new();
        
        await foreach (var movie in movieRepository.GetAllAsync(m => newMovies.Contains(m.Title), cancellationToken)
                           .WithCancellation(cancellationToken))
        {
            dbMovies.Add(movie);
        }
        return dbMovies.Select(m=>new MovieDto
        {
            Id = m.Id,
            Director = m.Director,
            Rate = m.Rate,
            Title = m.Title,
            Year = m.Year
        }).ToList();
    }

    private void AllocateMovies(List<Task> tasks, MovieDto dm, HashSet<string> newMovies, CancellationToken cancellationToken)
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
                                    newMovies.Add(newMovie.Title);
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
