namespace Ecommerce.Interfaces.Persistence;

public interface IGenericRepository<T> where T : class,IDomainEntity
{
    Task AddAsync(T entity,CancellationToken cancellationToken);
    Task DeleteAsync (T entity);
    Task UpdateAsync(T entity);
    
    Task<IReadOnlyList<T>?> GetAllAsNoTrackingAsync(CancellationToken cancellationToken = default);
    public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>?> GetAllWithSpecsAsync(ISpecifications<T> specs,
    CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>?> GetAllWithSpecsAsNoTrackingAsync(ISpecifications<T> specs,
    CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync<TID>(TID id, CancellationToken cancellationToken) where TID : notnull;
    Task<T?> GetByIdAsNotTrackingAsync<TID>(TID id, CancellationToken cancellationToken) where TID : notnull;
    Task<T?> GetByIdWithSpecsAsNotTrackingAsync(ISpecifications<T> specs,
    CancellationToken cancellationToken = default);

    Task<T?> GetByIdWithSpecsWithTrackingAsync(ISpecifications<T> specs,
         CancellationToken cancellationToken = default);

    Task<int> GetCountAsync(ISpecifications<T> specification, CancellationToken cancellationToken = default);

    Task<bool> ExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);

    Task ExecuteDeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
   
    Task ExecuteUpdateAsync(Expression<Func<T, bool>> expression,
        Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls,
        CancellationToken cancellationToken);
}
