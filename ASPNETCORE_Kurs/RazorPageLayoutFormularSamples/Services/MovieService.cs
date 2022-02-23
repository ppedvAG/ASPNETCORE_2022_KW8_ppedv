using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Services
{
    public class MovieService : IMovieService
    {
        private IList<Movie> _movieList;

        public MovieService()
        {
            _movieList = new List<Movie>();

            _movieList.Add(new Movie() { Id = 1, Title = "Jurassic Park", Description = "T-Rex wird Veggie", Price = 9.99m, Genre = MovieGenre.Action });
            _movieList.Add(new Movie() { Id = 2, Title = "Jurassic Park 2", Description = "T-Rex beginnt Grundlagenforschung", Price = 19.99m, Genre = MovieGenre.Docu });
            _movieList.Add(new Movie() { Id = 3, Title = "Batman", Description = "Batman und Joker werden Freunde", Price = 29.99m, Genre = MovieGenre.Action });

        }


        public void Add(Movie movie)
        {
            _movieList.Add(movie);
        }

        public void Delete(int id)
        {
            Movie movie = GetById(id);

            

            _movieList.Remove(movie);
        }

        public IList<Movie> GetAll()
        {
            return _movieList;
        }

        public Movie GetById(int? id)
        {
            Movie? movie = _movieList.FirstOrDefault(x => x.Id == id);
            
            if (movie == null)
                throw new Exception();

            return movie;
        }

        public void Update(int id, Movie movie)
        {
            Movie? orginalMovie = GetById(id);
            orginalMovie = movie;
        }
    }
}
