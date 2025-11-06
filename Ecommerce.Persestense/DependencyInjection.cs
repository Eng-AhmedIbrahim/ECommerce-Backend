using Ecommerce.Interfaces.Persistence;
using Ecommerce.Persestense.Persistence.GenericRepository;

namespace Ecommerce.Persestense;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
