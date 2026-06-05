namespace GameStoreApp.Domain.Entities;
public class Genre// its the Genre of games
{
    public int Id { get; set; } // Primary key for Genre Entity
    public string Name { get; set; } = string.Empty;//aneme of genre example FPS, ACTION game
    public ICollection<Game> Games { get; set; } = new List<Game>(); //collection of games that is for a certain genre
}
