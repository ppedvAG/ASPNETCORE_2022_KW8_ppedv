using RazorPageLayoutFormularSamples.Models;
using System.Linq.Expressions;

namespace RazorPageLayoutFormularSamples.Services
{
    public interface IMovieService
    {
        //einfaches Crud 
        IList<Movie> GetAll();
        IEnumerable<Movie> GetByConditions(string searchString);

        Movie GetById (int? id);

        
        void Add(Movie movie);
        void Update(int id, Movie movie);
        void Delete(int id);
    }
}
