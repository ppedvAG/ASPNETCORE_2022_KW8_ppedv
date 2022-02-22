using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage_Konfiguration_Samples.Pages.ConfigurationSamples
{
    public class IConfigurationExplizietReadModel : PageModel
    {
        private readonly IConfiguration _configuration; 

        //Ctor + tab tab -> Shortcut für Konstrutkor
        public IConfigurationExplizietReadModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ContentResult OnGet() //!QAchtung ContentResult gibt kein HTML aus...es wird nur der String - Inhalt ausgegeben
        {
            string myKeyValue = _configuration["MyKey"];

            string title = _configuration["Position:Titel"];
            string name = _configuration["Position:Name"];

            string defaultLogLevel = _configuration["Logging:LogLevel:Default"];

            return Content($"MYKey value: {myKeyValue} \n" +
                $"Title: {title} \n" +
                $"Name : {name} \n " +
                $"Default LogLevel: {defaultLogLevel}");
        }
    }
}
