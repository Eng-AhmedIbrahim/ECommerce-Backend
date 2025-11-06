namespace Ecommerce.Api.Base.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        //services.AddHttpClient();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = (actionContext) =>
            {
                var errors = actionContext.ModelState.Where(p => p.Value?.Errors.Count() > 0)
                .SelectMany(p => p.Value?.Errors ?? new())
                .Select(e => e.ErrorMessage)
                .ToArray();

                var validationErrorResponse = new ApiValidationErrorResponse(errors);

                return new BadRequestObjectResult(validationErrorResponse);
            };
        });

        services.AddAutoMapper(typeof(MappingProfile));

        services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

        

        services.AddScoped<IAccountServices, AccountServices>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}