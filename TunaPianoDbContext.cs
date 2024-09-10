using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Data;
using Tuna_Piano.Models;

namespace Tuna_Piano
{
    public class TunaPianoDbContext :DbContext
    {
        public DbSet<Artist> Artists {  get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song>  Songs { get; set; }

        public TunaPianoDbContext(DbContextOptions<TunaPianoDbContext> context) : base(context) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(ArtistData.Artists);
            modelBuilder.Entity<Genre>().HasData(GenreData.Genres);
            modelBuilder.Entity<Song>().HasData(SongData.Songs);
        }
    }

}
