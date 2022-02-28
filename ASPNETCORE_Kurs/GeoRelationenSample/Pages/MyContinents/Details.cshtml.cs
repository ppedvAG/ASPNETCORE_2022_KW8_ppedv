#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoRelationenSample.Data;
using GeoRelationenSample.Models;

namespace GeoRelationenSample.Pages.MyContinents
{
    public class DetailsModel : PageModel
    {
        private readonly GeoRelationenSample.Data.GeoDbContext _context;

        public DetailsModel(GeoRelationenSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Continent = await _context.Continents.FirstOrDefaultAsync(m => m.Id == id);

            if (Continent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
