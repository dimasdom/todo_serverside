﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace todo_serverside.Photos
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}
