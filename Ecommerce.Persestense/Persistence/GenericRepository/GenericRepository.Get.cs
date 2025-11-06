namespace Ecommerce.Persestense.Persistence.GenericRepository;

public partial class GenericRepository<T> where T : class, IDomainEntity
{
    public async Task<T?> GetByIdAsync<TID>(TID id, CancellationToken cancellationToken = default) where TID : notnull
        => await _dbContext.Set<T>()
        .FindAsync([id], cancellationToken: cancellationToken);

    public async Task<T?> GetByIdWithSpecsAsNotTrackingAsync(ISpecifications<T> specs, CancellationToken cancellationToken = default)
        => await ApplySpecification(specs)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    public async Task<T?> GetByIdWithSpecsWithTrackingAsync(ISpecifications<T> specs, CancellationToken cancellationToken = default)
     => await ApplySpecification(specs)
        .FirstOrDefaultAsync(cancellationToken: cancellationToken);


    public async Task<IReadOnlyList<T>?> GetAllWithSpecsAsync(ISpecifications<T> specs, CancellationToken cancellationToken = default)
        => await ApplySpecification(specs)
        .ToListAsync();

    public async Task<IReadOnlyList<T>?> GetAllWithSpecsAsNoTrackingAsync(ISpecifications<T> specs,
    CancellationToken cancellationToken = default)
        => await ApplySpecification(specs)
                .AsNoTracking()
                .ToListAsync();


    public async Task<IReadOnlyList<T>?> GetAllAsNoTrackingAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Set<T>()
        .AsNoTracking()
        .ToListAsync(cancellationToken: cancellationToken);

    public async Task<IReadOnlyList<T>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbContext.Set<T>()
            .ToListAsync();

    public async Task<T?> GetByIdAsNotTrackingAsync<TID>(TID id, CancellationToken cancellationToken) where TID : notnull
      => await _dbContext.Set<T>()
        .AsNoTracking()
        .FirstOrDefaultAsync(e => EF.Property<TID>(e, "Id")!.Equals(id), cancellationToken);
}
