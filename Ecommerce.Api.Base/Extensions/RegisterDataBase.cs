namespace Ecommerce.Api.Base.Extensions;

public static class RegisterDataBase
{
    public static IServiceCollection AddDataBaseConnections(this IServiceCollection services , string DefaultConnection = default!)
    {
        services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(DefaultConnection));


        services.AddDbContext<AppIdentityDbContext>(options => options
                 .UseSqlServer(DefaultConnection));

        return services;
    }
}
