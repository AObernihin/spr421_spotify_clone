using AutoMapper;
using spr421_spotify_clone.BLL.Dtos.Track;
using spr421_spotify_clone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.MapperProfiles
{
    public class TrackProfile : Profile
    {
        public TrackProfile()
        {
            CreateMap<CreateTrackDto, TrackEntity>()
                .ForMember(dest => dest.AudioUrl, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.GenreId, opt => opt.Ignore());
        }
    }
}
