using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.DAL.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AvatarUrl { get; set; }
        
            public virtual ICollection<ApplicationUserClaim> Claims { get; set; } = [];
            public virtual ICollection<ApplicationUserLogin> Logins { get; set; } = [];
            public virtual ICollection<ApplicationUserToken> Tokens { get; set; } = [];
            public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = [];
        
        
    }
}
