using Common.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace Common.Helpers.Files
{
    public class ManageFiles : IManageFiles
    {
        public bool DeleteFile(string path, string fileName)
        {
            throw new NotImplementedException();
        }

        public string UploadFile(IFormFile file, string path)
        {
            throw new NotImplementedException();
        }
    }
}
