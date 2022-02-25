#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Pages.OnlineStore
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly RazorPageLayoutFormularSamples.Data.MovieDbContext _context;

        public IndexModel(RazorPageLayoutFormularSamples.Data.MovieDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }


        public async Task<IActionResult> OnPostBuy(int? id)
        {
            IList<int> idList = new List<int>();

            if (HttpContext.Session.Keys.Contains("ShoppingCart"))
            {
                string jsonIdList = HttpContext.Session.GetString("ShoppingCart");
                idList = JsonConvert.DeserializeObject<List<int>>(jsonIdList);
            }

            idList.Add(id.Value);
            string jsonString = JsonConvert.SerializeObject(idList);
            HttpContext.Session.SetString("ShoppingCart", jsonString);

            return RedirectToPage("./Index");
        }
    }
}
