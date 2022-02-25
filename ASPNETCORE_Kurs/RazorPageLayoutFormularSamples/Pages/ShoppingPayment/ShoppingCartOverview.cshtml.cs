#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Pages.ShoppingPayment
{
    public class ShoppingCartOverviewModel : PageModel
    {
        private readonly RazorPageLayoutFormularSamples.Data.MovieDbContext _context;

        public ShoppingCartOverviewModel(RazorPageLayoutFormularSamples.Data.MovieDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            //Movie = await _context.Movies.ToListAsync();
            

            //Hier fragen wir, ob die Session als Featureüberhaupt aktiv ist 
            if (HttpContext.Session.IsAvailable)
            {
                Movie = InitializeShoppingCart();
            }
            
        }

        private IList<Movie> InitializeShoppingCart()
        {
            ////if (!HttpContext.Session.Keys.Contains("ShoppingCart"))
            ////    throw new Exception("Warenkorb ist intern noch nicht verfügbar");

            IList<Movie> movieList = new List<Movie>();
            
            List<int> ids = ReadShoppingPaymentFromSession();

            foreach (int currentArticleId in ids)
            {
                Movie currentMovie = _context.Movies.Find(currentArticleId);
                movieList.Add(currentMovie);
            }
            return movieList;
        }
        private List<int> ReadShoppingPaymentFromSession()
        {
            string shoppingCartJsonString = HttpContext.Session.GetString("ShoppingCart");
            List<int> ids = JsonConvert.DeserializeObject<List<int>>(shoppingCartJsonString);

            return ids;
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            List<int> ids = ReadShoppingPaymentFromSession();

            if (ids.Contains(id.Value))
            {
                ids.Remove(id.Value);

                if (ids.Count == 0)
                {
                    HttpContext.Session.Remove("ShoppingCart");
                }
                else
                {
                    string jsonString = JsonConvert.SerializeObject(ids);
                    HttpContext.Session.SetString("ShoppingCart", jsonString);
                }
            }


            return RedirectToPage("./ShoppingCartOverview");
        }
    }
}
