#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoRelationenSample.Data;
using GeoRelationenSample.Models;

namespace GeoRelationenSample.Pages.MyContinents
{
    public class CreateModel : PageModel
    {
        private readonly GeoRelationenSample.Data.GeoDbContext _context;

        public CreateModel(GeoRelationenSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Continent Continent { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Continents.Add(Continent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
