namespace Ecommerce.Persestense.Persistence.GenericRepository;

public partial class GenericRepository<T> where T : class, IDomainEntity
{
    public Task UpdateAsync(T entity)
    {
        if (_dbContext.Entry(entity).State == EntityState.Detached)
            _dbContext.Set<T>()
                .Update(entity);

        return Task.CompletedTask;
    }
    public async Task ExecuteUpdateAsync(Expression<Func<T, bool>> expression, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls, CancellationToken cancellationToken)
        => await _dbContext.Set<T>()
            .Where(expression)
            .ExecuteUpdateAsync(setPropertyCalls, cancellationToken: cancellationToken);
}