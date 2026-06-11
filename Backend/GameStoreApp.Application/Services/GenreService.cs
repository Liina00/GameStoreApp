using System;
using GameStoreApp.Domain.Entities;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreApp.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.Select(g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name,
            });
        }
        public async Task<GenreDto?> GetByIdAsync(int id)//gets "a" genre by its ID
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
                return null;
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }
        public async Task<GenreDto> CreateAsync(GenreDto dto)//create new GENRE
        {
            var genre = new Genre
            {
                Name = dto.Name
            };
            await _genreRepository.AddAsync(genre);
            dto.Id = genre.Id;
            return dto;
        }
        public async Task<GenreDto?> UpdateAsync(int id, GenreDto dto)//updates a genre
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
                return null;

            genre.Name = dto.Name;
            await _genreRepository.UpdateAsync(genre);
            return dto;
        }
        public async Task<bool> DeleteAsync(int id)//deletes a genre
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null)
                return false;
            await _genreRepository.DeleteAsync(id);
            return true;
        }
    }
}
