namespace Ecommerce.Domain.Specifications;

public class BaseSpecifications<T> : ISpecifications<T> where T : class, IDomainEntity
{
    public Expression<Func<T, bool>>? Criteria { get ; set ; }
    public List<Expression<Func<T, object>>>? Includes { get; set; } = [];
    public List<string>? IncludeStrings { get; set; } = [];
    public Expression<Func<T, object>>? OrderBy { get ; set ; }
    public Expression<Func<T, object>>? OrderByDescending { get ; set ; }
    public bool IsPaginationEnabled { get ; set ; }
    public int Take { get ; set ; }
    public int Skip { get ; set ; }

    public BaseSpecifications() { }

    public BaseSpecifications(Expression<Func<T, bool>>? critria)
        => Criteria = critria;

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
     => OrderBy = orderByExpression;

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        => OrderByDescending = orderByDescExpression;
    protected void ApplyPagination(int skip, int take)
    {
        IsPaginationEnabled = true;
        Skip = skip;
        Take = take;
    }
}