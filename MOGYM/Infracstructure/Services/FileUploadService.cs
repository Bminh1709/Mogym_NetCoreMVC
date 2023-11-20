using MOGYM.Infracstructure.Interfaces;

namespace MOGYM.Infracstructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        public bool DeleteFile(string fileName, string folderName)
        {
            try
            {
                string directoryPath = Path.Combine("wwwroot", "Image", folderName);
                string filePath = Path.Combine(directoryPath, fileName);

                // Check if the file exists
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> UploadFile(IFormFile file, string folderName)
        {
            try
            {
                if (file.Length > 0)
                {
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/" + folderName));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    // Create unique file name
                    string uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + file.FileName;

                    using (var fileStream = new FileStream(Path.Combine(path, uniqueFileName), FileMode.Create))
                    {
                        await file.OpenReadStream().CopyToAsync(fileStream);
                    }

                    // Return the file path
                    return uniqueFileName;
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw new ArgumentException("Tải file gặp lỗi");
            }
        }
    }
}
