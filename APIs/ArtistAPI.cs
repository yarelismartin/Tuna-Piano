using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;

namespace Tuna_Piano.APIs
{
    public class ArtistAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/api/artists", (TunaPianoDbContext db, Artist newArtist) =>
            {
                db.Artists.Add(newArtist);
                db.SaveChanges();
                return Results.Created($"/api/artists/{newArtist.Id}", newArtist);
            });

            app.MapDelete("/api/artists/{artistId}", (TunaPianoDbContext db, int artistId) =>
            {
                Artist removeArtist = db.Artists.SingleOrDefault(a => a.Id == artistId);
                if (removeArtist != null)
                {
                    db.Artists.Remove(removeArtist);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound("No artist matches this id");
                }
            });

            app.MapGet("/api/artists/{artistId}", (TunaPianoDbContext db, int artistId) =>
            {
                Artist getSingle = db.Artists
                .Include(a => a.Songs)
                .SingleOrDefault(a => a.Id == artistId);
                if (getSingle != null)
                {
                    return Results.Ok(getSingle);
                }
                else
                {
                    return Results.NotFound("There is not artist that matches this id");
                }
            });

            app.MapGet("/api/artists", (TunaPianoDbContext db) =>
            {
                var allArtist = db.Artists.ToList();
                if (allArtist != null)
                {
                    return Results.Ok(allArtist);
                }
                else
                {
                    return Results.Ok("There are no artist to display");
                }
            });

            app.MapPut("/api/artists/{artistId}", (TunaPianoDbContext db, int artistId, Artist artist) =>
            {
                Artist artistUpdate = db.Artists.SingleOrDefault(a => a.Id == artistId);
                if (artistUpdate != null)
                {
                    artistUpdate.Name = artist.Name;
                    artistUpdate.Age = artist.Age;
                    artistUpdate.Bio = artist.Bio;

                    db.SaveChanges();
                    return Results.Ok(artistUpdate);

                }
                else
                {
                    return Results.NotFound("No artist found with this id");
                }
            });

        }
    }
}
