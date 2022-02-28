using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageLayoutFormularSamples.Pages.GallerySample
{
    public class Gallery2Model : PageModel
    {
        //Property f�r Razor-UI 
        public string[] PicturePaths { get; set; }


        public void OnGet()
        {
            string imageDirectoryPath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\";
            PicturePaths = Directory.GetFiles(imageDirectoryPath);
        }
    }
}
