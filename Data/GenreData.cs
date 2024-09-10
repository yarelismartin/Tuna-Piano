using Tuna_Piano.Models;

namespace Tuna_Piano.Data
{
    public class GenreData
    {
        public static List<Genre> Genres = new List<Genre>
        {
            new Genre { Id = 1, Description = "Rock" },
            new Genre { Id = 2, Description = "Classical" },
            new Genre { Id = 3, Description = "Pop" },
            new Genre { Id = 4, Description = "Country" },
            new Genre { Id = 5, Description = "Jazz" }
        };
    }
}
