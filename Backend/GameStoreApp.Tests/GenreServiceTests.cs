using Xunit;
using NSubstitute;
using FluentAssertions;
using GameStoreApp.Application.Services;
using GameStoreApp.Application.Interfaces;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Domain.Entities;

namespace GameStoreApp.Tests
{
    public class GenreServiceTests
    {
        private readonly IGenreRepository _genreRepo = Substitute.For<IGenreRepository>();
        private GenreService CreateService() => new GenreService(_genreRepo);

        [Fact]
        public async Task GetAllAsync_ShouldReturnListOfGenres()
        {
            _genreRepo.GetAllAsync().Returns(new List<Genre>
            {
                new Genre { Id = 1, Name = "FPS" }
            });

            var service = CreateService();
            var result = await service.GetAllAsync();

            result.Should().HaveCount(1);
            result.First().Name.Should().Be("FPS");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnGenre_WhenFound()
        {
            _genreRepo.GetByIdAsync(1).Returns(new Genre { Id = 1, Name = "RPG" });

            var service = CreateService();
            var result = await service.GetByIdAsync(1);

            result.Should().NotBeNull();
            result!.Name.Should().Be("RPG");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            _genreRepo.GetByIdAsync(1).Returns((Genre?)null);

            var service = CreateService();
            var result = await service.GetByIdAsync(1);

            result.Should().BeNull();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddGenre()
        {
            var dto = new GenreDto { Name = "Adventure" };

            var service = CreateService();
            var result = await service.CreateAsync(dto);

            await _genreRepo.Received(1).AddAsync(Arg.Any<Genre>());
            result.Name.Should().Be("Adventure");
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnUpdatedDto_WhenGenreExists()
        {
            _genreRepo.GetByIdAsync(1).Returns(new Genre { Id = 1, Name = "Old" });

            var dto = new GenreDto { Name = "Updated" };

            var service = CreateService();
            var result = await service.UpdateAsync(1, dto);

            result.Should().NotBeNull();
            result!.Name.Should().Be("Updated");
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenGenreExists()
        {
            _genreRepo.GetByIdAsync(1).Returns(new Genre { Id = 1 });

            var service = CreateService();
            var result = await service.DeleteAsync(1);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenGenreNotFound()
        {
            _genreRepo.GetByIdAsync(1).Returns((Genre?)null);

            var service = CreateService();
            var result = await service.DeleteAsync(1);

            result.Should().BeFalse();
        }
    }
}

