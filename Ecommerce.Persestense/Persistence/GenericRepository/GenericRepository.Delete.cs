namespace Ecommerce.Persestense.Persistence.GenericRepository;

public partial class GenericRepository<T> where T : class, IDomainEntity
{
    public Task DeleteAsync(T entity)
    {
        if(_dbContext.Entry(entity).State == EntityState.Detached)
            _dbContext.Set<T>().Remove(entity);

        return Task.CompletedTask;
    }

    public Task ExecuteDeleteAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        =>_dbContext.Set<T>()
        .Where(expression)
        .ExecuteDeleteAsync(cancellationToken);
}
