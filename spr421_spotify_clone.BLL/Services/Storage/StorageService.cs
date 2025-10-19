
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Storage
{
    public class StorageService : IStorageService
    {
        public async Task<string?> SaveAudioFileAsync(IFormFile audioFile, string folderPath)
        {
            var types = audioFile.ContentType.Split("/");

            if(types.Length != 2 || types[0] != "audio")
            {
                return null;
            }

            string extension = Path.GetExtension(audioFile.FileName);
            string fileName = $"{Guid.NewGuid().ToString()}{extension}";
            string filePath = Path.Combine(folderPath, fileName);

           

            using (var fileStream = File.Create(filePath))
            {
                
                await audioFile.CopyToAsync(fileStream);
            }
            var tagsFile = TagLib.File.Create(filePath);

            tagsFile.Tag.Album = "Patron";
            tagsFile.Tag.Year = 2022;
            tagsFile.Save();

            return fileName;
                
        }
    }
}
