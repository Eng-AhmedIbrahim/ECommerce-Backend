using Microsoft.EntityFrameworkCore.Storage;

namespace Ecommerce.Interfaces.Persistence;

public interface IUnitOfWork : IAsyncDisposable
{
    public IGenericRepository<T> Repository<T>() where T : class, IDomainEntity;
    public Task<int> CompleteAsync(CancellationToken cancellationToken);

    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
