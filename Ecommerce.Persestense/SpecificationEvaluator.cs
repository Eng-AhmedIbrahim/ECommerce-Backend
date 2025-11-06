namespace Ecommerce.Persestense;

public static class SpecificationEvaluator<T> where T : class ,IDomainEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecifications<T> specs)
    {
        var query = inputQuery;

        if (specs.Criteria is not null)
            query =  query.Where(specs.Criteria);

        if(specs.OrderBy is not null)
            query = query.OrderBy(specs.OrderBy);

        if(specs.OrderByDescending is not null)
            query = query.OrderByDescending(specs.OrderByDescending);

        if (specs.IsPaginationEnabled)
            query = query
                .Skip(specs.Skip)
                .Take(specs.Take);

        query = specs.Includes!.Aggregate(query, (currentQuery, includeQuery) =>
            currentQuery.Include(includeQuery));
       
        query = specs.IncludeStrings!.Aggregate(query,(currentQuery, includeStrings) =>
        currentQuery.Include(includeStrings));

        return query;
    }
}
