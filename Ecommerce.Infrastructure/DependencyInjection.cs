namespace Ecommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddECommerceInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAccountServices, AccountServices>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<IProductAttributeService, ProductAttributeService>();
        services.AddScoped<ICarouselService, CarouselService>();
        services.AddScoped<IExternalLoginServices, ExternalLoginServices>();
        services.AddScoped<IWishlistService, WishlistService>();
        services.AddScoped<ICartService, CartService>();


        return services;
    }
}