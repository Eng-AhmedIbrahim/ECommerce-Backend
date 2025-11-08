namespace Ecommerce.Persestense.Data.ApplicationDbContext.DataSeed;

public static class MenemDataSeed
{

    private static readonly List<string> potentialFilePaths =
   [
       Path.Combine("Data", "ApplicationDbContext","DataSeed","JsonFiles"),
        Path.Combine("..", "Ecommerce.Persestense", "Data","ApplicationDbContext" ,"DataSeed","JsonFiles"),
    ];

    public static async Task SeedAsync(AppDbContext appDbContext,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {

        if (!appDbContext.Carousels.Any())
        {

            var carousels = await GetDataFromJsonFile<Carousel>("MenemSeedsCarousel.json");

            if (carousels != null && carousels.Any())
            {
                appDbContext.Carousels.AddRange(carousels);
                await appDbContext.SaveChangesAsync();
            }
        }

        if (!userManager.Users.Any())
        {
            var adminUser = new AppUser
            {
                FullName = "Administrator",
                NormalizedFullName = "ADMINISTRATOR",
                UserName = "admin",
                Email = "roma2001342@gmail.com",
                NormalizedEmail = "ROMA2001342@GMAIL.COM",
                DateOfBirth = new DateTime(2002, 10, 1),
                PhoneNumber = "01033964899",
                HasAcceptedTerms = true,
                ProfilePictureUrl = string.Empty
            };

            var result = await userManager.CreateAsync(adminUser, "12312300Aa#@");

            if (!result.Succeeded)
            {
                Log.Error("Failed to create admin user: {Errors}",
                    string.Join(", ", result.Errors.Select(e => e.Description)));
                return;
            }

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        if (!appDbContext.Categories.Any())
        {
            Log.Warning("Looking for file at: {FilePath} Cats2");

            var categoriesDto = await GetDataFromJsonFile<CategorySeedDto>("MenemSeedsCategories.json");
            
            Log.Warning("Looking for file at: {FilePath} Cats2", categoriesDto);

            if (categoriesDto == null)
                return;

            foreach (var c in categoriesDto)
            {
                var category = new Category
                {
                    Index = c.Index,
                    ArabicName = c.ArabicName,
                    EnglishName = c.EnglishName,
                    ArabicDescription = c.ArabicDescription,
                    EnglishDescription = c.EnglishDescription,
                };

                foreach (var p in c.Products)
                {
                    var product = new Product
                    {
                        ArabicName = p.ArabicName,
                        EnglishName = p.EnglishName,
                        Price = p.Price,
                        DiscountPercentage = p.DiscountPercentage,
                        StockQuantity = p.StockQuantity,
                        IsActive = p.IsActive,
                        Images = p.Images.Select(i => new ProductImage
                        {
                            Url = i,
                            IsMain = true
                        }).ToList(),
                    };

                    foreach (var v in p.Variants)
                    {
                        product.Variants.Add(new ProductVariant
                        {
                            ProductAttributeId = 1,
                            ArabicValue = v.ArabicValue,
                            EnglishValue = v.EnglishValue,
                            Price = v.Price,
                            StockQuantity = v.StockQuantity,
                            ImageUrl = v.ImageUrl
                        });
                    }

                    category.Products.Add(product);
                }

                appDbContext.Categories.Add(category);
            }

            await appDbContext.SaveChangesAsync();

        }
    }


    private static string FindValidFilePath(List<string> paths, string fileName)
    {
        foreach (var path in paths)
        {
            var fullPath = Path.Combine(path, fileName);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
        }
        return string.Empty;
    }
    public static async Task<List<T>> GetDataFromJsonFile<T>(string fileName)
    {
        var filePath = FindValidFilePath(potentialFilePaths, fileName);
        if (string.IsNullOrEmpty(filePath))
            return new List<T>();

        var data = await File.ReadAllTextAsync(filePath);
        var result = JsonSerializer.Deserialize<List<T>>(data);
        return result ?? new List<T>();
    }
}