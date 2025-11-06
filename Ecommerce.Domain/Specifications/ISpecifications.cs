namespace Ecommerce.Domain.Specifications;

public interface ISpecifications<T> where T : class , IDomainEntity
{
    public Expression<Func<T,bool>>? Criteria { get; set; }
    public List<Expression<Func<T, object>>>? Includes { get; set; }
    public List<string>? IncludeStrings { get; set; }
    public Expression<Func<T,object>>? OrderBy { get; set; }
    public Expression<Func<T,object>>? OrderByDescending { get; set; }

    public bool IsPaginationEnabled { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }
}