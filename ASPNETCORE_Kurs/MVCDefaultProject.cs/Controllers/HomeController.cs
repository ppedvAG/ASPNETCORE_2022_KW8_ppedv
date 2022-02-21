using Microsoft.AspNetCore.Mvc;
using MVCDefaultProject.cs.Models;
using MVCDefaultProject.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace MVCDefaultProject.cs.Controllers
{

    //MVC ein Controller bedient mehrere Views 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<ToDo> toDoList = new List<ToDo>();


        //Konstruktor eines Controllers wird pro Seiten-Call neu aufgerufen -> eine Factory - Klasse erstellt jedesmal eine neue Instanz von der Controller-Klasse
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            toDoList.Add(new ToDo() { Id = 2, WorkName = "Essen kochen", IsDone = false });
        }

        public IActionResult Index() //Get-Methode für Index -> InRzorPages wäre das die Index.cs-> OnGet
        {
           
            toDoList.Add(new ToDo() { Id = 1, WorkName = "Katze füttern", IsDone=false });
            toDoList.Add(new ToDo() { Id = 2, WorkName = "PC kaufen", IsDone = false });


            return View(toDoList); //MVC verwendet keine Properties und muss seine Daten via return View(/*Daten*/) übermitteln
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}