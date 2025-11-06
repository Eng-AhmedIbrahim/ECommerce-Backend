
namespace Ecommerce.Persestense.Persistence;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly Hashtable _repositories = [];
    
    public IGenericRepository<T> Repository<T>() where T : class, IDomainEntity
    {
        var key = typeof(T).FullName;
        if (!_repositories.ContainsKey(key!))
        {
            var repository = new GenericRepository<T>(_dbContext);
            _repositories.Add(key!, repository);
        }
        return _repositories[key!] as IGenericRepository<T> ?? new GenericRepository<T>(_dbContext);
    }
    
    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        => await _dbContext.SaveChangesAsync();
    
    public ValueTask DisposeAsync()
        => _dbContext.DisposeAsync();

    public async Task<IDbContextTransaction> BeginTransactionAsync() => await _dbContext.Database.BeginTransactionAsync();
    public async Task CommitTransactionAsync() => await _dbContext.Database.CommitTransactionAsync();
    public async Task RollbackTransactionAsync() => await _dbContext.Database.RollbackTransactionAsync();
}