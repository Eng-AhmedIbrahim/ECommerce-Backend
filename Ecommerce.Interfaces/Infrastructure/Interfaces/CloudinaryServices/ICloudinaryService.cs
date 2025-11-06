namespace Ecommerce.Interfaces.Infrastructure.Interfaces.CloudinaryServices;

public interface ICloudinaryService
{
    public Task<string> UploadImageAsync(IFormFile file);
    public Task<List<string>> UploadImagesAsync(ICollection<IFormFile> files);
    public Task<bool> DeleteImageAsync(string url);
    public Task<Dictionary<string, bool>> DeleteImagesAsync(List<string> publicIds);
}