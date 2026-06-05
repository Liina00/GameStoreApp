using GameStoreApp.Domain.Entities;

namespace GameStoreApp.Application.Interfaces
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();//gets all genres
        Task<Genre?> GetByIdAsync(int id);//gets the genres by its ID
        Task AddAsync(Genre genre);//adds a new genre
        Task UpdateAsync(Genre genre);//updates a genre, for example from FPS to RPG
        Task DeleteAsync(int id); //delete GENRE by id
    }
}
