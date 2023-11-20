namespace MOGYM.Infracstructure.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IFormFile file, string folderName);
        bool DeleteFile(string fileName, string folderName);
    }
}
