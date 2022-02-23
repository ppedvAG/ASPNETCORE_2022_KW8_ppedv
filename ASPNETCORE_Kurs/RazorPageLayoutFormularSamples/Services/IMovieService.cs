using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Services
{
    public interface IMovieService
    {
        //einfaches Crud 
        IList<Movie> GetAll();

        Movie GetById (int? id);

        void Add(Movie movie);
        void Update(int id, Movie movie);
        void Delete(int id);
    }
}
