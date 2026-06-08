using Microsoft.EntityFrameworkCore;
using GameStoreApp.Infrastructure.Data;
using GameStoreApp.Domain.Entities;
using GameStoreApp.Application.Interfaces;

namespace GameStoreApp.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository//this class for db operations for the GAME entity, using EFC
    {
        private readonly GameStoreAppDbContext _context;
        public GameRepository(GameStoreAppDbContext context)//constructor injection, injext the databse context
        {
            _context = context;
        }
        public async Task<IEnumerable<Game>> GetAllAsync()//Gets akk games and ts connexted genre, CSGO and it get the genre the GAME has aswell
        {
            return await _context.Games.Include(g => g.Genre).ToListAsync();
        }
        public async Task<Game?> GetByIdAsync(int id)//gets a game BY ID and aswell the genre that game has if it has
        {
            return await _context.Games.Include(g => g.Genre).FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task AddAsync(Game game)//Adding new GAME to DB
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();//commiting the INSERTT to db saving
        }
        public async Task UpdateAsync(Game game)//Updates a game
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)//deltes a game
        {
            var game = await _context.Games.FindAsync(id);
            if(game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();//saves the changes it commits the wanted delete to db 
            }
        }
    }
}