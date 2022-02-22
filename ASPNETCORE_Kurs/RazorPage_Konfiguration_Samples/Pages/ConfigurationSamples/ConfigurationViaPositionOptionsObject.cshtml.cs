using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RazorPage_Konfiguration_Samples.Models;

namespace RazorPage_Konfiguration_Samples.Pages.ConfigurationSamples
{
    public class ConfigurationViaPositionOptionsObjectModel : PageModel
    {
        private readonly PositionOptions positionOptions;


        //IOption-Patern -> 
        public ConfigurationViaPositionOptionsObjectModel(IOptionsSnapshot<PositionOptions> positionConfiguration)
        {
            positionOptions = positionConfiguration.Value;
        }
        public ContentResult OnGet()
        {
            return Content($"Title: {positionOptions.Title} \n" +
                $"Name: {positionOptions.Name}");
        }
    }
}
