namespace Ecommerce.Api.Base.Helpers;

public class DocumentSetting
{
    private readonly IWebHostEnvironment _env;
    public DocumentSetting(IWebHostEnvironment env)
     =>   _env = env;

    public string UploadFile(IFormFile file, string folderName)
    {
        string folderPath = Path.Combine(_env.WebRootPath, "Files", folderName);

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        string fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        string filePath = Path.Combine(folderPath, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return Path.Combine("Files", folderName, fileName).Replace("\\", "/");
    }

    public bool DeleteFile(string filePath)
    {
        try
        {
            string fullPath = Path.Combine(_env.WebRootPath, filePath);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return false;
        }
    }
}
