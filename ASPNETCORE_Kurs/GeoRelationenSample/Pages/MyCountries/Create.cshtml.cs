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

namespace GeoRelationenSample.Pages.Countries
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
            ViewData["ContinentId"] = new SelectList(_context.Continents, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Country Country { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Countries.Add(Country);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
