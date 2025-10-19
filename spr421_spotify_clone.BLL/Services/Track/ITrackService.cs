using spr421_spotify_clone.BLL.Dtos.Track;
using spr421_spotify_clone.BLL.Services.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Track
{
    public interface ITrackService
    {
        Task<ServiceResponse> CreateAsync(CreateTrackDto dto, string audioFilePath);
    }
}
