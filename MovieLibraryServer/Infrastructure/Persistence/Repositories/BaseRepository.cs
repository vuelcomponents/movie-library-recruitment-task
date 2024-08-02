using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieLibraryServer.Infrastructure.Persistence.Data;

namespace MovieLibraryServer.Infrastructure.Persistence.Repositories;


public abstract class BaseRepository<T>(MovieLibraryDataContext movieLibraryDataContext) : IBaseRepository<T>
    where T : class
{
    protected readonly MovieLibraryDataContext MovieLibraryDataContext = movieLibraryDataContext;
    
    public virtual async Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>>? include = null,
        CancellationToken? cancellationToken =  null
    )
    {
        return include != null
            ? await MovieLibraryDataContext.Set<T>().Include(include).FirstOrDefaultAsync(predicate)
            : await MovieLibraryDataContext.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public virtual async IAsyncEnumerable<T> GetAllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken? cancellationToken = null)
    {
        if (predicate != null)
        {
            await foreach (var movie in MovieLibraryDataContext.Set<T>().Where(predicate).AsAsyncEnumerable())
            {
                yield return movie;
            }
        }
        else
        {
            await foreach (var movie in MovieLibraryDataContext.Set<T>().AsAsyncEnumerable())
            {
                yield return movie;
            }
        }
        
    }
    public virtual async Task<T> Create(T entity, CancellationToken? cancellationToken = null)
    {
        await MovieLibraryDataContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public virtual async Task SaveAsync(CancellationToken? cancellationToken = null)
    {
        await MovieLibraryDataContext.SaveChangesAsync();
    }

}
