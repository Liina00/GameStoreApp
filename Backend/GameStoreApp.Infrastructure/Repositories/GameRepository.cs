using Microsoft.EntityFrameworkCore;
using GameStoreApp.Infrastructure.Data;
using GameStoreApp.Domain.Entities;
using GameStoreApp.Application.Interfaces;

namespace GameStoreApp.Infrastructure.Repositories
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameStoreAppDbContext context) : base(context){}
        public override async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.Include(g => g.Genre).ToListAsync();
        }
        public override async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.Include(g =>g.Genre)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}