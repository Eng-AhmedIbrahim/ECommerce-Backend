namespace Ecommerce.Api.Base.Extensions;

public static class AddAutoMigrationSettings
{
    public static async Task<WebApplication> AddAutoMigrationService(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        var _dbContext = services.GetService<AppDbContext>();
        var _identity = services.GetService<AppIdentityDbContext>();

        try
        {
            if (_dbContext is not null)
                await _dbContext.Database.MigrateAsync();

            if (_identity is not null)
                await _identity.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error During Auto Migrate");
        }

        return app;
    }
}
