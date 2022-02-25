using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Models;
using RazorPageLayoutFormularSamples.Services;

namespace RazorPageLayoutFormularSamples.Pages.BackOffice
{
    [Authorize("BackOfficeUser")]
    public class IndexModel : PageModel
    {
        //private readonly IMovieService movieSerivce;
        private readonly MovieDbContext movieDbContext;

        public IList<Movie> MovieList { get; set; }

        //Wir greifen mit Konstruktor-Injektion auf den IOC Container zu und lesen unsere MovieService-Instanz herauf
        //public IndexModel(IMovieService movieService)
        //{
        //    //this.movieSerivce = movieService;
        //}

        public IndexModel(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }



        //Browser called WebServer 
        //Webseite wird im Get-Block vorbereitet > Ergebnis (HTML-Document) wird als Response, an dem Browser zurück gegeeben
        public void OnGet()
        {
            MovieList = movieDbContext.Movies.ToList();
        }


        public void OnPost()
        {

        }
    }
}
