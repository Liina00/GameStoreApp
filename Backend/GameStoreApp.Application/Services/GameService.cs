using System;
using GameStoreApp.Domain.Entities;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GameStoreApp.Application.Services
{
    public class GameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGenreRepository _genreRepository;

        public GameService(IGameRepository gameRepository, IGenreRepository genreRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<GameDto>> GetAllAsync()//Gets all games
        {
            var games = await _gameRepository.GetAllAsync();

            return games.Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                Description = g.Description,
                ReleaseYear = g.ReleaseYear,
                GenreName = g.Genre?.Name ?? ""
            });
        }
        public async Task<GameDto?> GetByIdAsync(int id)//Gets game by its ID, maps to DTO 
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
                return null;
            return new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Price = game.Price,
                Description = game.Description,
                ReleaseYear = game.ReleaseYear,
                GenreName = game.Genre?.Name ?? ""
            };
        }
        public async Task AddAsync(GameDto dto)//create new GAme
        {
            var genre = await _genreRepository.GetByIdAsync(dto.Id);
            if (genre == null)
                throw new Exception("Genre not found...");

            var game = new Game
            {
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                ReleaseYear = dto.ReleaseYear,
                GenreId = genre.Id
            };
            await _gameRepository.AddAsync(game);
        }
        public async Task UpdateAsync(int id, GameDto dto) //updates a GAME
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
                throw new Exception("Game not found..");
            game.Title = dto.Title;
            game.Price = dto.Price;
            game.Description = dto.Description;
            game.ReleaseYear = dto.ReleaseYear;

            await _gameRepository.UpdateAsync(game);
        }
        public async Task DeleteAsync(int id)//delets a GAME
        {
            await _gameRepository.DeleteASync(id);
        }
    }
}
