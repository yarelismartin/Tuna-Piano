using Tuna_Piano.Models;

namespace Tuna_Piano.Data
{
    public class ArtistData
    {
        public static List<Artist> Artists = new List<Artist>
        {
            new Artist { Id = 1, Name = "The Beatles", Age = 60, Bio = "Legendary Rock Band" },
            new Artist { Id = 2, Name = "Ludwig van Beethoven", Age = 50, Bio = "Classical Music Composer" },
            new Artist { Id = 3, Name = "Queen", Age = 20, Bio = "Rock Band" },
            new Artist { Id = 4, Name = "Taylor Swift", Age = 33, Bio = "Country Pop Singer-Songwriter" },
            new Artist { Id = 5, Name = "Bob Dylan", Age = 82, Bio = "Folk Rock Singer-Songwriter" }
        };
    }
}
