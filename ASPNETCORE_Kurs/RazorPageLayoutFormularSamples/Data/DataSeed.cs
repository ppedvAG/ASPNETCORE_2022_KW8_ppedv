using Microsoft.EntityFrameworkCore;
using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Data
{
    public static class DataSeed
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            using (MovieDbContext ctx = new MovieDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieDbContext>>()))
            {
                

                ctx.Movies.Add(new Movie() { Id = 1, Title = "Jurassic Park", Description = "T-Rex wird Veggie", Price = 9.99m, ReleaseYear = 1999, Genre = MovieGenre.Action });
                ctx.Movies.Add(new Movie() { Id = 2, Title = "Jurassic Park 2", Description = "T-Rex beginnt Grundlagenforschung", ReleaseYear = 1999, Price = 19.99m, Genre = MovieGenre.Docu });
                ctx.Movies.Add(new Movie() { Id = 3, Title = "Batman", Description = "Batman und Joker werden Freunde", Price = 29.99m, ReleaseYear = 2010, Genre = MovieGenre.Action });
                ctx.SaveChanges();
            }
        }
    }
}
