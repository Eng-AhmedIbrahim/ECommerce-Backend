namespace Ecommerce.Persestense.Persistence.GenericRepository;

public partial class GenericRepository<T> : IGenericRepository<T> where T : class, IDomainEntity
{
    private readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
     => _dbContext = dbContext;

    public async Task<bool> ExistAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        => await _dbContext.Set<T>().AsNoTracking()
                .AnyAsync(expression, cancellationToken: cancellationToken);

    public async Task<T?> FindAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
       => await _dbContext.Set<T>().AsNoTracking()
                .FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);

    public async Task<int> GetCountAsync(ISpecifications<T> specification, CancellationToken cancellationToken = default)
        => await ApplySpecification(specification)
                .AsNoTracking()
                .CountAsync();

    private IQueryable<T> ApplySpecification(ISpecifications<T> specs)
        => SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>(), specs);

}