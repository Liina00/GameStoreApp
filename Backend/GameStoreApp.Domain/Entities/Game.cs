namespace GameStoreApp.Domain.Entities;
public class Game
{
    public int Id { get; set; } // primary key of the "GAME" ENITITY
    public string Title { get; set; } = string.Empty;//TItle of the GAME
    public string Description { get; set; } = string.Empty;// descripotion of the GAME
    public decimal Price { get; set; } // Price of the GAME

    //this is for GENRE
    public int GenreId { get; set; } //this is the FOREIGN KEY for reference the "GENRE" ENTITY"
    public Genre? Genre { get; set; } // this is the NAVIGATION PROPERTY for reference the "GENRE" ENTITY" 
}
