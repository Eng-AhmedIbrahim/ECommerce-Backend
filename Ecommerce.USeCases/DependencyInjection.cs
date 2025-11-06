namespace Ecommerce.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddEcommerceUseCasesServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddHttpContextAccessor();

        return services;
    }
}