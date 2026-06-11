using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStoreApp.Application.DTOs;

namespace GameStoreApp.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllAsync();
        Task<GenreDto?> GetByIdAsync(int id);
        Task<GenreDto> CreateAsync(GenreDto dto);
        Task<GenreDto?> UpdateAsync(int id, GenreDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
