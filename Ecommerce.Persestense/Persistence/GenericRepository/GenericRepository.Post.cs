namespace Ecommerce.Persestense.Persistence.GenericRepository;

public partial class GenericRepository<T> where T : class, IDomainEntity
{
    public async Task AddAsync(T entity, CancellationToken cancellationToken)
     => await _dbContext.Set<T>().AddAsync(entity, cancellationToken: cancellationToken);

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
        => await _dbContext.Set<T>().AddRangeAsync(entities, cancellationToken: cancellationToken);
}
