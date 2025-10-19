using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Dtos.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "login is required")]
        public required string Login { get; set; }

        [Required(ErrorMessage = "password is required")]
        public required string Password { get; set; }
    }
}
