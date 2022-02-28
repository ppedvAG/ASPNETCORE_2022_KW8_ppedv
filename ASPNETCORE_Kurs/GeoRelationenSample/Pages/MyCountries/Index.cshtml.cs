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

namespace GeoRelationenSample.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly GeoRelationenSample.Data.GeoDbContext _context;

        public IndexModel(GeoRelationenSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; }

        public async Task OnGetAsync()
        {
            Country = await _context.Countries
                .Include(c => c.Continent).ToListAsync();
        }
    }
}
