namespace Ecommerce.Api.Base.Extensions;

public static class AddAutoMigrationSettings
{
    public static async Task<WebApplication> AddAutoMigrationService(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var _dbContext = services.GetRequiredService<AppDbContext>();
            var _identity = services.GetRequiredService<AppIdentityDbContext>();
            var _userManager = services.GetRequiredService<UserManager<AppUser>>();
            var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await _dbContext.Database.MigrateAsync();
            await _identity.Database.MigrateAsync();

            await MenemDataSeed.SeedAsync(
                _dbContext,
                _userManager,
                _roleManager
            );
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error During Auto Migrate");
        }

        return app;
    }
}
