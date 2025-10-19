using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Dtos.Genre
{
    public class CreateGenreDto
    {
        [Required(ErrorMessage = "Id is required")]
        [MaxLength(50)]
        public required string Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        [MinLength(2)]
        public required string Name { get; set; }
    }
}
