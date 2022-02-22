using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RazorPage_Konfiguration_Samples.Models;

namespace RazorPage_Konfiguration_Samples.Pages.ConfigurationSamples
{
    public class ArraySampleModel : PageModel
    {
        public ArrayExample MyArray { get; set; }

        public ArraySampleModel(IOptionsSnapshot<ArrayExample> array)
        {
            MyArray = array.Value;
        }
        public void OnGet()
        {
        }
    }
}
