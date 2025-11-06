namespace Ecommerce.Infrastructure.Services.CloudinaryServices;

public class CloudinaryService : ICloudinaryService
{
    private readonly Cloudinary _cloudinary;
    public CloudinaryService(IConfiguration configuration)
    {
        var account = new Account
        {
            Cloud = Guard.Against.NullOrEmpty(configuration["CloudinarySetting:CloudName"]),
            ApiKey = Guard.Against.NullOrEmpty(configuration["CloudinarySetting:ApiKey"]),
            ApiSecret = Guard.Against.NullOrEmpty(configuration["CloudinarySetting:ApiSecret"])
        };
        _cloudinary = new Cloudinary(account);
    }
    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file.Length <= 0)
            throw new ArgumentException("File is empty", nameof(file));
        await using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            Transformation = new Transformation().Quality("auto")
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
        if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            throw new Exception("Image upload failed");

        return uploadResult.SecureUrl.ToString();
    }

    public async Task<List<string>> UploadImagesAsync(ICollection<IFormFile> files)
    {
        var urls = new List<string>();

        foreach (var file in files)
        {
            if (file.Length <= 0) continue;

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Quality("auto")
            };


            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                urls.Add(uploadResult.SecureUrl.ToString());
            }
        }

        return urls;
    }

    public async Task<bool> DeleteImageAsync(string url)
    {
        var publicId = ExtractPublicIdFromUrl(url);
        var deletionParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deletionParams);
        return result.Result == "ok";
    }

    public async Task<Dictionary<string, bool>> DeleteImageAsync(List<string> publicIds)
    {
        var results = new Dictionary<string, bool>();

        foreach (var publicId in publicIds)
        {
            var deletionParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deletionParams);
            results[publicId] = result.Result == "ok";
        }

        return results;
    }

    public async Task<Dictionary<string, bool>> DeleteImagesAsync(List<string> publicIds)
    {
        var deletionParams = new DelResParams()
        {
            PublicIds = publicIds
        };

        var result = await _cloudinary.DeleteResourcesAsync(deletionParams);

        var results = new Dictionary<string, bool>();

        foreach (var publicId in publicIds)
        {
            results[publicId] = result.Deleted.ContainsKey(publicId)
                                && result.Deleted[publicId] == "deleted";
        }

        return results;
    }


    private string ExtractPublicIdFromUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("URL is null or empty", nameof(url));

        var uri = new Uri(url);
        var segments = uri.Segments;

        if (segments.Length == 0)
            throw new ArgumentException("Invalid URL format", nameof(url));

        var fileName = segments.Last();

        var publicId = Path.GetFileNameWithoutExtension(fileName);

        return publicId;
    }
}