using MovieLibraryServer.Domain.Dto;
using MovieLibraryServer.Domain.Entities;
using MovieLibraryServer.Infrastructure.Persistence.Data;
using Z.EntityFramework.Plus;

namespace MovieLibraryServer.Infrastructure.Persistence.Repositories;

public interface IMovieRepository<TMovie> : IBaseRepository<TMovie>
{
    Task DeleteManyByIdDtoList(List<IdDto> entities);
}

public sealed class MovieRepository(MovieLibraryDataContext movieLibraryDataContext) : BaseRepository<Movie>(movieLibraryDataContext), IMovieRepository<Movie>
{
    public Task DeleteManyByIdDtoList(List<IdDto> entities)
    {
        List<long> productIds = entities.Select(p => p.Id).ToList();
        var list = MovieLibraryDataContext.Movies.Where(dbP => productIds.Contains(dbP.Id));
        list.DeleteAsync();
        return Task.CompletedTask;
    }
}