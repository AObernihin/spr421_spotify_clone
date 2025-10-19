using spr421_spotify_clone.BLL.Dtos.Auth;
using spr421_spotify_clone.BLL.Services.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse> LoginAsync(LoginDto dto);
    }
}
