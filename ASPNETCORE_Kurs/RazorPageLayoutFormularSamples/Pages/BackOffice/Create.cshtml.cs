using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Models;
using RazorPageLayoutFormularSamples.Services;

namespace RazorPageLayoutFormularSamples.Pages.BackOffice
{
    public class CreateModel : PageModel
    {
        private readonly MovieDbContext movieDbContext;

        [BindProperty]
        public Movie Movie { get; set; }

        public CreateModel(MovieDbContext movieService)
        {
            this.movieDbContext = movieService;
        }

        public IActionResult OnGet()
        {
            //Wir zeigen ein leeres Formular ohne Daten an
            return Page();
        }

        public IActionResult OnPost()
        {

            //Geschäftsregel: Prüfung ob Titel auf dem Film-Index für verbotene Filme gibt
            if (Movie.Title == "The Crow")
            {
                ///IsValid wird auf false gesetzt
                ModelState.AddModelError("Movie.Title", "Der Film steht auf dem Index");
            }

            //Serverseite Validierung
            if(!ModelState.IsValid)
            {
                return Page(); //Wenn der Datensatz nicht richtig ausgefüllt wurde (Kriterien nicht eingehalten) 
                               //Wird der komplette Datensatz mit Fehlermeldung nochmals angezeigt
            }

            movieDbContext.Movies.Add(Movie);
            movieDbContext.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
