using GameStoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApp.Infrastructure.Data;
public class GameStoreAppDbContext : DbContext
{
    public GameStoreAppDbContext(DbContextOptions<GameStoreAppDbContext> options):base(options){ }
    public DbSet<Game> Games => Set<Game>();//reps the GAME table in db
    public DbSet<Genre> Genres => Set<Genre>();//reps the GENRE table in DB
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Genre)
            .WithMany(g => g.Games)
            .HasForeignKey(g => g.GenreId)
            .OnDelete(DeleteBehavior.Cascade);
        //this is name required for genre
        modelBuilder.Entity<Genre>()
            .Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(50);
        //this is game title req
        modelBuilder.Entity<Game>()
            .Property(g => g.Title)
            .IsRequired()
            .HasMaxLength(100);
    }
}
