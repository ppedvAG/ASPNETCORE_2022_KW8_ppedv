using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageLayoutFormularSamples.Models;

namespace RazorPageLayoutFormularSamples.Pages.RazorSyntaxExamples
{
    public class OverviewModel : PageModel
    {

        public List<Car> Cars { get; set; }

        public void OnGet()
        {
            Cars = new List<Car>();
            Cars.Add(new Car { Id = 1, Brand = "VW", Model = "Polo" });
            Cars.Add(new Car { Id = 2, Brand = "Porsche", Model = "GT3" });
            Cars.Add(new Car { Id = 3, Brand = "Ford", Model = "SMax" });
            Cars.Add(new Car { Id = 4, Brand = "Ferrari", Model = "Enzo" });
        }

        public void OnPost()
        {
            
        }
    }
}
