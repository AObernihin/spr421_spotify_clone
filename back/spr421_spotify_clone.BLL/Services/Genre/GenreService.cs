using AutoMapper;
using Microsoft.EntityFrameworkCore;
using spr421_spotify_clone.BLL.Dtos.Genre;
using spr421_spotify_clone.DAL.Entities;
using spr421_spotify_clone.DAL.Repositories.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace spr421_spotify_clone.BLL.Services.Genre
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public async Task<ServiceResponse> CreateAsync(CreateGenreDto dto)
        {
            if(await _genreRepository.IsExistsAsync(dto.Name))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Genre '{dto.Name}' already exists",
                    StatusCode = HttpStatusCode.BadRequest

                };
            }
            var entity = _mapper.Map<GenreEntity>(dto);
            await _genreRepository.CreateAsync(entity);

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = $"Genre '{dto.Name}' created successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ServiceResponse> DeleteAsync(string id)
        {
            var entity = await _genreRepository.GetByIdAsync(id);

            if(entity == null)
            {
                return new ServiceResponse { 
                    IsSuccess = false,
                    Message = $"Genre with id '{id}' not found",
                    StatusCode = HttpStatusCode.NotFound
                }
                    ;
            }
            await _genreRepository.DeleteAsync(entity);

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = $"Genre with id '{id}' deleted successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ServiceResponse> GetAll()
        {
        var entities = await _genreRepository.Genres.ToListAsync();
            var dtos = _mapper.Map<List<GenreDto>>(entities);

            return new ServiceResponse
            {
                
                Message = "Genres retrieved successfully",
                
                Payload = dtos
            };
        }

        public async Task<ServiceResponse> GetById(string id)
        {
            var entity = await _genreRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Genre with id '{id}' not found",
                    StatusCode = HttpStatusCode.NotFound
                }
                    ;
            }

            var dto = new GenreDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = $"Genre with id '{id}' retrieved successfully",
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
        }

        public async Task<ServiceResponse> GetByName(string name)
        {
            var entity = await _genreRepository.GetByNameAsync(name);
        if (entity == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Genre with name '{name}' not found",
                    StatusCode = HttpStatusCode.NotFound
                }
                    ;
            }

            var dto = new GenreDto
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = $"Genre with name '{name}' retrieved successfully",
                StatusCode = HttpStatusCode.OK,
                Payload = dto
            };
            
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateGenreDto dto)
        {
            if (await _genreRepository.IsExistsAsync(dto.Name))
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Genre '{dto.Name}' already exists",
                    StatusCode = HttpStatusCode.BadRequest

                };
            }
            var entity = await _genreRepository.GetByIdAsync(dto.Id);

            if (entity == null)
            {
                return new ServiceResponse
                {
                    IsSuccess = false,
                    Message = $"Genre with id '{dto.Id}' not found",
                    StatusCode = HttpStatusCode.NotFound
                }
                    ;
            }

            entity.Name = dto.Name;
            entity.NormalizedName = dto.Name.ToUpper();
            await _genreRepository.UpdateAsync(entity);

            _genreRepository.UpdateAsync(entity);

            return new ServiceResponse
            {
                IsSuccess = true,
                Message = $"Genre '{dto.Name}' updated successfully",
                StatusCode = HttpStatusCode.OK
            };
           
        }
    }
}
