using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Storage
{
    public interface IStorageService
    {
        Task<string?> SaveAudioFileAsync(IFormFile audiofile,string folderPath);
        
            
    }
}
