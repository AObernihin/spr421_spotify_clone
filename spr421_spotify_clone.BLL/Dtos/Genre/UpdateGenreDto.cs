using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Dtos.Genre
{
    public class UpdateGenreDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}
