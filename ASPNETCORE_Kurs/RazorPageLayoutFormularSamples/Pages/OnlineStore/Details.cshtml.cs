using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageLayoutFormularSamples.Models;
using RazorPageLayoutFormularSamples.Services;

namespace RazorPageLayoutFormularSamples.Pages.OnlineStore
{
    public class DetailsModel : PageModel
    {
        private readonly IMovieService movieService;

        public Movie Movie { get; set; }

        public DetailsModel(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        //Aufbauen und Anzeigen einer Webseite
        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Movie = movieService.GetById(id.Value);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page(); //Expliziet rufen wir die RazorPage Seite auf 
        }
    }
}
