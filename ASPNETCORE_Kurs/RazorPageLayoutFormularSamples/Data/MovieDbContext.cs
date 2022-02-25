using Microsoft.EntityFrameworkCore;
using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Data
{
    public class MovieDbContext :DbContext //Microsoft.EntityFrameworkCore;
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) //ConnectionString
            :base(options)
        {

        }

        //Tabellen in Objekt-Form
        public DbSet<Movie> Movies { get; set; }
    }
}
