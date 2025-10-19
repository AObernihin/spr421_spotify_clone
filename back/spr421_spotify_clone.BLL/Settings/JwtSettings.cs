using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Settings
{
   public class JwtSettings
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }

        public string? SecretKey { get; set; }

        public int ExpiresHours { get; set; }

    }
}
