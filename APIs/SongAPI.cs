using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;

namespace Tuna_Piano.APIs
{
    public class SongAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/api/songs", (TunaPianoDbContext db, Song newSong) =>
              {
                db.Songs.Add(newSong);
                db.SaveChanges();
                return Results.Created($"/api/songs/{newSong.Id}", newSong);
           });

            app.MapDelete("/api/songs/{songId}", (TunaPianoDbContext db, int songId) =>
            {
                Song songToDelete = db.Songs.SingleOrDefault(s => s.Id == songId);
                if (songToDelete != null)
                {
                    db.Songs.Remove(songToDelete);
                    db.SaveChanges();
                    return Results.NoContent(); //204 no content
                }
                else
                {
                    return Results.NotFound("There is no song matching this id.");
                }
            });

            app.MapGet("/api/songs/{songId}", (TunaPianoDbContext db, int songId) =>
            {
                Song singleSong = db.Songs
                .Include(s => s.Genres)
                .SingleOrDefault(s => s.Id == songId);
                if(singleSong != null)
                {
                    return Results.Ok(singleSong);
                }
                else
                {
                    return Results.NotFound("No Song Found.");
                }
            });
        }


    }
}
