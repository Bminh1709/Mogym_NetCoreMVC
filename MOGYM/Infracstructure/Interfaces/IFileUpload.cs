namespace MOGYM.Infracstructure.Interfaces
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IFormFile file);
    }
}
