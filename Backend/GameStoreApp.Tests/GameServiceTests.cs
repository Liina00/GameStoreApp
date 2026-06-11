using Xunit;
using NSubstitute;
using FluentAssertions;
using GameStoreApp.Application.Services;
using GameStoreApp.Application.Interfaces;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Domain.Entities;

namespace GameStoreApp.Tests
{
    public class GameServiceTests
    {
        private readonly IGameRepository _gameRepo = Substitute.For<IGameRepository>();
        private readonly IGenreRepository _genreRepo = Substitute.For<IGenreRepository>();

        private GameService CreateService() => new GameService(_gameRepo, _genreRepo);

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfGames()
        {
            _gameRepo.GetAllAsync().Returns(new List<Game>
            {
                new Game { Id = 1, Title = "CS2", GenreId = 1, Genre = new Genre { Name = "FPS" } }
            });

            var service = CreateService();
            var result = await service.GetAllAsync();

            result.Should().HaveCount(1);
            result.First().Title.Should().Be("CS2");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnGame_WhenFound()
        {
            _gameRepo.GetByIdAsync(1).Returns(new Game
            {
                Id = 1,
                Title = "CS2",
                GenreId = 1,
                Genre = new Genre { Name = "FPS" }
            });

            var service = CreateService();
            var result = await service.GetByIdAsync(1);

            result.Should().NotBeNull();
            result!.Title.Should().Be("CS2");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            _gameRepo.GetByIdAsync(1).Returns((Game?)null);

            var service = CreateService();
            var result = await service.GetByIdAsync(1);

            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateGame()
        {
            _genreRepo.GetByIdAsync(1).Returns(new Genre { Id = 1, Name = "FPS" });

            var dto = new GameDto
            {
                Title = "New Game",
                Price = 100,
                Description = "Test",
                ReleaseYear = 2024,
                GenreId = 1
            };

            var service = CreateService();
            var result = await service.CreateAsync(dto);

            await _gameRepo.Received(1).AddAsync(Arg.Any<Game>());
            result.Title.Should().Be("New Game");
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedDto_WhenGameExists()
        {
            _gameRepo.GetByIdAsync(1).Returns(new Game { Id = 1, Title = "Old" });

            var dto = new GameDto
            {
                Title = "Updated",
                Price = 200,
                Description = "New",
                ReleaseYear = 2025,
                GenreId = 1
            };

            var service = CreateService();
            var result = await service.UpdateAsync(1, dto);

            result.Should().NotBeNull();
            result!.Title.Should().Be("Updated");
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull_WhenGameNotFound()
        {
            _gameRepo.GetByIdAsync(1).Returns((Game?)null);

            var service = CreateService();
            var result = await service.UpdateAsync(1, new GameDto());

            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenGameExists()
        {
            _gameRepo.GetByIdAsync(1).Returns(new Game { Id = 1 });

            var service = CreateService();
            var result = await service.DeleteAsync(1);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenGameNotFound()
        {
            _gameRepo.GetByIdAsync(1).Returns((Game?)null);

            var service = CreateService();
            var result = await service.DeleteAsync(1);

            result.Should().BeFalse();
        }
    }
}
