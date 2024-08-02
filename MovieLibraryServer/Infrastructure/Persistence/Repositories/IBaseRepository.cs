using System.Linq.Expressions;

namespace MovieLibraryServer.Infrastructure.Persistence.Repositories;

public interface IBaseRepository<T>
{
    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>>? include = null
    );
    IAsyncEnumerable<T> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> Create(T entity);
    Task SaveAsync();
}