#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Pages.OnlineStore
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageLayoutFormularSamples.Data.MovieDbContext _context;

        public DetailsModel(RazorPageLayoutFormularSamples.Data.MovieDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
