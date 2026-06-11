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

            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();

            builder.Services.AddScoped<GameService>();
            builder.Services.AddScoped<GenreService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //CORS Add for vite on the 5173 port
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")//this is the port fir front
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend"); //this for front 
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
