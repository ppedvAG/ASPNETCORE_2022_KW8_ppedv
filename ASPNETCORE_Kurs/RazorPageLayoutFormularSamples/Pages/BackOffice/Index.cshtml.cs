using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageLayoutFormularSamples.Models;
using RazorPageLayoutFormularSamples.Services;

namespace RazorPageLayoutFormularSamples.Pages.BackOffice
{
    public class IndexModel : PageModel
    {
        private readonly IMovieService movieSerivce;


        public IList<Movie> MovieList { get; set; }

        //Wir greifen mit Konstruktor-Injektion auf den IOC Container zu und lesen unsere MovieService-Instanz herauf
        public IndexModel(IMovieService movieService)
        {
            this.movieSerivce = movieService;
        }



        //Browser called WebServer 
        //Webseite wird im Get-Block vorbereitet > Ergebnis (HTML-Document) wird als Response, an dem Browser zurück gegeeben
        public void OnGet()
        {
            MovieList = movieSerivce.GetAll();
        }


        public void OnPost()
        {

        }
    }
}
