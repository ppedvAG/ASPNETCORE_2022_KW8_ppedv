using ASPNETCORE_RazorPage_DISample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCORE_RazorPage_DISample.Pages
{
    public class IndexModel : PageModel
    {
        //Achtung auch der ILogger liegt im IOC Container
        private readonly ILogger<IndexModel> _logger;
        private readonly ITimeService _timeService;
        
        //Property -> Können in der View zugreifen 
        public string TimeOutput { get; set; }


        //Inection -< Konstuktor Injections
        public IndexModel(ILogger<IndexModel> logger, ITimeService timeService) //greifen auf den IOC Container und lesen ICarService heraus
        {
            _logger = logger;
            _timeService = timeService; //
        }

        public void OnGet()
        {
            TimeOutput = _timeService.GetTime();
        }
    }
}