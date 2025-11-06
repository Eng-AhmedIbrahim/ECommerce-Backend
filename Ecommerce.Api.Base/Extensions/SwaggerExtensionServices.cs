namespace Ecommerce.Api.Base.Extensions;

public static class SwaggerExtensionServices
{
    private const string Bearer = "Bearer";

    public static IServiceCollection AddSwaggerServiceCollection(
        this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(s =>
        {
            s.AddSecurityDefinition(Bearer, new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = Bearer,
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = Bearer
                        },
                        Name = Bearer
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }
}
