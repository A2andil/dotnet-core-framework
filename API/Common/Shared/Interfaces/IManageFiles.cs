using Microsoft.AspNetCore.Http;

namespace Common.Shared.Interfaces
{
    public interface IManageFiles
    {
        bool DeleteFile(string path, string fileName);

        string UploadFile(IFormFile file, string path);
    }
}
