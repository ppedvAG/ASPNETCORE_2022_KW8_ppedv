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
    public class IndexModel : PageModel
    {
        private readonly GeoRelationenSample.Data.GeoDbContext _context;

        public IndexModel(GeoRelationenSample.Data.GeoDbContext context)
        {
            _context = context;
        }

        public IList<Continent> Continent { get;set; }

        public async Task OnGetAsync()
        {
            Continent = await _context.Continents.ToListAsync();
        }
    }
}
