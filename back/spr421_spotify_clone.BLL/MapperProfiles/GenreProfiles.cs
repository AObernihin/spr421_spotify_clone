using AutoMapper;
using spr421_spotify_clone.BLL.Dtos.Genre;
using spr421_spotify_clone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.MapperProfiles
{
    public class GenreProfiles : Profile
    {
        public GenreProfiles()
        {
            //CreateGenreDto -> GenreEntity
            CreateMap<CreateGenreDto, GenreEntity>()
                .ForMember(dest=>dest.NormalizedName,opt=>opt.MapFrom(src=>src.Name.ToUpper()));

            //UpdateGenreDto -> GenreEntity
            CreateMap<UpdateGenreDto, GenreEntity>()
                .ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.Name.ToUpper()));

            CreateMap<GenreEntity, GenreDto>();
        }
    }
}
