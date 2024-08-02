using System.Linq.Expressions;

namespace MovieLibraryServer.Infrastructure.Persistence.Repositories;

public interface IBaseRepository<T>
{
    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>>? include = null,
        CancellationToken? cancellationToken = null
    );
    IAsyncEnumerable<T> GetAllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken? cancellationToken = null);
    Task<T> Create(T entity, CancellationToken? cancellationToken = null);
    Task SaveAsync(CancellationToken? cancellationToken = null);
}