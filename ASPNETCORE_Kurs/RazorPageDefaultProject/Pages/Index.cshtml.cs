using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageDefaultProject.Models;

namespace RazorPageDefaultProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) #//Konstruktor wird bei jedem Seitenaurfur neu Initialisiert
        {
            _logger = logger;

            ToDoList = new List<ToDo>();
            ToDoList.Add(new ToDo () { Id = 1, WorkName="ASPNET CORE Kurs", IsDone=false });

        }

        //Razor Pages -> Daten werden als Properties in der Code-Behind hinterlegt

        //Flache Variante -> es gibt eine besser Implementierung
        public DateTime CurrentTime { get; set; }
        public string ToDo { get; set; }    


        //Variante 2 ist die Best Pratice
        //STRG plus . 
        public List<ToDo> ToDoList { get; set; }    

        public void OnGet() //Wenn die Webseite aufgerufen wird, können wir in OnGet -> Initializierungen vornehmen
        {
            ToDoList.Add(new ToDo() { Id = 2, WorkName = "Katze füttern", IsDone = false });
        }
    }
}