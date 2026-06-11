using GameStoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GameStoreApp.Infrastructure.Data;
using GameStoreApp.Application.Interfaces;

namespace GameStoreApp.Infrastructure.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameStoreAppDbContext context) : base(context)
        {
        }
    }
}