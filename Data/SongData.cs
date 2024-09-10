using Tuna_Piano.Models;

namespace Tuna_Piano.Data
{
    public class SongData
    {
        public static List<Song> Songs = new List<Song>
        {
            new Song { Id = 1, Title = "Hey Jude", ArtistId = 1, Album = "Hey Jude", Length = 228 },
            new Song { Id = 2, Title = "Moonlight Sonata", ArtistId = 2, Album = "For Elise", Length = 580 },
            new Song { Id = 3, Title = "Bohemian Rhapsody", ArtistId = 3, Album = "A Night at the Opera", Length = 595 },
            new Song { Id = 4, Title = "Shake It Off", ArtistId = 4, Album = "1989", Length = 200 },
            new Song { Id = 5, Title = "Blowin' in the Wind", ArtistId = 5, Album = "The Freewheelin' Bob Dylan", Length = 320 }
        };
    }
}
