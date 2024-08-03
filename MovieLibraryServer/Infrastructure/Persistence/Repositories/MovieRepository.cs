using System.Collections.Frozen;
using Microsoft.EntityFrameworkCore;
using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Domain.Entities;
using MovieLibraryServer.Infrastructure.Persistence.Data;

namespace MovieLibraryServer.Infrastructure.Persistence.Repositories;

public interface IMovieRepository : IBaseRepository<Movie>
{
    Task DeleteManyByIdDtoList(List<IdDto> entities, CancellationToken? cancellationToken = null);
}

public sealed class MovieRepository(MovieLibraryDataContext movieLibraryDataContext) : BaseRepository<Movie>(movieLibraryDataContext), IMovieRepository
{
    public async Task DeleteManyByIdDtoList(List<IdDto> entities, CancellationToken? cancellationToken = null)
    {
        FrozenSet<long> productIds = entities.Select(p => p.Id).ToFrozenSet();
        var list = MovieLibraryDataContext.Movies.Where(dbP => productIds.Contains(dbP.Id)).AsAsyncEnumerable();
        await foreach (var movie in list.WithCancellation(cancellationToken ?? CancellationToken.None))
        {
            MovieLibraryDataContext.Movies.Remove(movie); 
        }
    }
}