using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreApp.Application.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; }= string.Empty;
        public int ReleaseYear { get; set; }
        //API return this Genrename and not the whole entity of genre
        public string GenreName { get; set; } = "";//Detta för outputten
        public int GenreId { get; set; }// genre id för inpout
    }
}
