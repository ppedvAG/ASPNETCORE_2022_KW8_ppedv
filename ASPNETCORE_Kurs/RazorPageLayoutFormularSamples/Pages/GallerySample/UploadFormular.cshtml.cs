using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageLayoutFormularSamples.Pages.GallerySample
{
    public class UploadFormularModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(IFormFile file) //IFormFile wird verwendet, wenn man generell Dateien Uploaden möchte
        {
            FileInfo fileInfo = new FileInfo(file.FileName);

            //absoluten Speicherpfad wird aufgebaut
            string savePath = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToPage("./UploadFormular");

        }
    }
}
