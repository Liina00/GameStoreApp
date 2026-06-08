using GameStoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GameStoreApp.Infrastructure.Data;
using GameStoreApp.Application.Interfaces;

namespace GameStoreApp.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository//hadnle operation for GENRE
    {
        private readonly GameStoreAppDbContext _context;
        public GenreRepository(GameStoreAppDbContext context)//inject db context
        {
            _context = context;
        }
        public async Task<IEnumerable<Genre>> GetAllAsync()//returning ALL the genres from db
        {
            return await _context.Genres.ToListAsync();
        }
        public async Task<Genre?> GetByIdAsync(int id)//gets a genre BY its ID
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddAsync(Genre genre)//adds new genre
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();//saves changes, adds then saves
        }
        public async Task UpdateAsync(Genre genre)//updates a genre
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();//saves the changes/update
        }
        public async Task DeleteAsync(int id)//Delete gebre by its ID, if found
        {
            var genre = await _context.Genres.FindAsync(id);
            if(genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();//saves here
            }
        }
    }
}