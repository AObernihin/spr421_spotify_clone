using spr421_spotify_clone.BLL.Dtos.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Genre
{
    public interface IGenreService
    {
        Task<ServiceResponse> CreateAsync(CreateGenreDto dto);
        Task<ServiceResponse> UpdateAsync(UpdateGenreDto dto);
        Task<ServiceResponse> DeleteAsync(string id);

        Task<ServiceResponse> GetById(string id);
        Task<ServiceResponse> GetByName(string name);
        Task<ServiceResponse> GetAll();
    }
}
