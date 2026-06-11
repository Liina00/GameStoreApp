using Microsoft.EntityFrameworkCore;
using GameStoreApp.Infrastructure.Data;
using GameStoreApp.Application.Interfaces;
using GameStoreApp.Application.Services;
using GameStoreApp.Infrastructure.Repositories;

namespace GameStoreApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //register DBxontrext
            builder.Services.AddDbContext<GameStoreAppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //generic reposiotry
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //repositories
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            //Services
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IGenreService, GenreService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
