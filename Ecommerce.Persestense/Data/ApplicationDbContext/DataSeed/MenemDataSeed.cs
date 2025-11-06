namespace Ecommerce.Persestense.Data.ApplicationDbContext.DataSeed;

public static class MenemDataSeed
{
    public static async Task SeedAsync(AppDbContext appDbContext, string webRootPath)
    {
        if (!appDbContext.Carousels.Any())
        {
            var filePath = Path.Combine(webRootPath, "JsonFiles", "SeedsCarousels.json");

            if (File.Exists(filePath))
            {
                var jsonData = await File.ReadAllTextAsync(filePath);
                var carousels = JsonSerializer.Deserialize<List<Carousel>>(jsonData);

                if (carousels != null && carousels.Any())
                {
                    appDbContext.Carousels.AddRange(carousels);
                    await appDbContext.SaveChangesAsync();
                }
            }
            else
               Log.Error($"Seed file not found: {filePath}");
        }

        if (!appDbContext.Categories.Any())
        {
            var filePath = Path.Combine(webRootPath, "JsonFiles", "SeedsCategories.json");

            if (File.Exists(filePath))
            {
                var jsonData = await File.ReadAllTextAsync(filePath);
                var categories = JsonSerializer.Deserialize<List<Category>>(jsonData);

                if (categories != null && categories.Any())
                {
                    appDbContext.Categories.AddRange(categories);
                    await appDbContext.SaveChangesAsync();
                }
            }
            else
                Log.Error($"Seed file not found: {filePath}");
        }
    }
}
