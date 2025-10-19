using Microsoft.AspNetCore.Mvc;
using spr421_spotify_clone.BLL.Dtos.Auth;
using spr421_spotify_clone.BLL.Services.Auth;
using spr421_spotify_clone.Extensions;
using System.Security.Cryptography.X509Certificates;

namespace spr421_spotify_clone.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        [HttpPost("login")]
            public async Task<IActionResult> LoginAsync([FromBody]LoginDto Dto)
            {
            var response = await _authService.LoginAsync(Dto);
            return this.ToActionResult(response);
            }
        [HttpPost("register")]
            public async Task<IActionResult> RegisterAsync()
            {
            return Ok();
            }
        
    }
}
