using AutoMapper;
using spr421_spotify_clone.BLL.Dtos.Track;
using spr421_spotify_clone.BLL.Services.Genre;
using spr421_spotify_clone.BLL.Services.Storage;
using spr421_spotify_clone.DAL.Entities;
using spr421_spotify_clone.DAL.Repositories.Genre;
using spr421_spotify_clone.DAL.Repositories.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Track
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        public TrackService(ITrackRepository trackRepository, IMapper mapper, IGenreRepository genreRepository)
        { 
            _trackRepository = trackRepository;
            _mapper = mapper;
            _genreRepository = genreRepository;
        }
        public async Task<ServiceResponse> CreateAsync(CreateTrackDto dto, string audioFilePath)
        {
           var entity = _mapper.Map<TrackEntity>(dto);

            var genre =  await _genreRepository.GetByIdAsync(dto.GenreId);

            if(genre == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Genre with id '{dto.GenreId}' not found"
                };
            }
            entity.Genre = genre;

           var fileName = await _storageService.SaveAudioFileAsync(dto.AudioFile, audioFilePath);

            if(fileName == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Audio file was not uploaded"
                };
            }
            entity.AudioUrl = fileName;
            await _trackRepository.CreateAsync(entity);

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = $"Track '{entity.Title}' created successfully",
                StatusCode = HttpStatusCode.OK
            };











           
        }
    }
}
