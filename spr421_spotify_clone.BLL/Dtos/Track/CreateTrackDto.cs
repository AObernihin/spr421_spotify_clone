using Microsoft.AspNetCore.Http;
using spr421_spotify_clone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Dtos.Track
{
    public class CreateTrackDto
    {
        [Required(ErrorMessage = "Title is required")]
        public required string Title { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "AudioFile is required")]
        public required IFormFile AudioFile { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "GenreId is required")]

        public required string GenreId { get; set; }
        
        
        
    }
}
  

