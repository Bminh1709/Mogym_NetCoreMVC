using MOGYM.Infracstructure.Interfaces;

namespace MOGYM.Infracstructure.Services
{
    public class FileUploadService : IFileUpload
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            string path = string.Empty;

            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image/Avatar"));
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
            catch (Exception ex)
            {
                throw new Exception("Tải file gặp lỗi", ex);
            }
        }
    }
}
