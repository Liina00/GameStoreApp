using GameStoreApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreApp.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>> GetAllAsync();
        Task<GameDto?> GetByIdAsync(int id);
        Task<GameDto> CreateAsync(GameDto dto);
        Task<GameDto?> UpdateAsync(int id, GameDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
