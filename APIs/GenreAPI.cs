using Microsoft.EntityFrameworkCore;
using Tuna_Piano.Models;

namespace Tuna_Piano.APIs
{
    public class GenreAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/api/genres", (TunaPianoDbContext db, Genre newGenre) =>
            {
                db.Genres.Add(newGenre);
                db.SaveChanges();
                return Results.Created($"/api/genres/{newGenre.Id}", newGenre);
            });

            app.MapDelete("/api/genres/{genreId}", (TunaPianoDbContext db, int genreId) =>
            {
                Genre removeGenre = db.Genres.SingleOrDefault(g => g.Id == genreId);
                if (removeGenre != null)
                {
                    db.Genres.Remove(removeGenre);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                else
                {
                    return Results.NotFound("No genre was found with that id");
                }
            });

            app.MapGet("/api/genres/{genreId}", (TunaPianoDbContext db, int genreId) =>
            {
                Genre singleGenre = db.Genres
                .Include(g => g.Songs)
                .SingleOrDefault(g => g.Id == genreId);
                if (singleGenre != null)
                {
                    return Results.Ok(singleGenre);
                }
                else
                {
                    return Results.NotFound("No genre found with this id");
                }
            });

            app.MapGet("/api/genres", (TunaPianoDbContext db) =>
            {
                var allGenres = db.Genres.ToList();
                if (allGenres.Any())
                {
                    return Results.Ok(allGenres);
                }
                else
                {
                    return Results.Ok("No genres to disaply");
                }
            });

            app.MapPut("/api/genres/{genreId}", (TunaPianoDbContext db, int genreId, Genre genre) =>
            {
                Genre updateGenre = db.Genres.SingleOrDefault(g => g.Id == genreId);
                if (updateGenre != null)
                {
                    updateGenre.Description = genre.Description;

                    db.SaveChanges();
                    return Results.Ok(updateGenre);
                }
                else
                {
                    return Results.NotFound("No genre was found under this id");
                }
            });

        }

    }
}
