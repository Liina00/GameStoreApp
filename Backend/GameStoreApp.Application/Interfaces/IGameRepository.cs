using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStoreApp.Domain.Entities;
using System.Threading.Tasks;

namespace GameStoreApp.Application.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();//gets the games from db
        Task<Game?> GetByIdAsync(int id);//gets game by its ID so very specific
        Task AddAsync(Game game);//Adds nbew game to DB
        Task UpdateAsync(Game game);//updates a game
        Task DeleteAsync(int id);//deletes a game by its ID
    }
}
