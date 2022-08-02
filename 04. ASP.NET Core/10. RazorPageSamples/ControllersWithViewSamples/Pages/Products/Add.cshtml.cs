using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControllersWithViewSamples.Pages.Products
{
    public class AddModel : PageModel
    {
        public void OnGet()
        {
            int a = 123;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            //Add 
            //Update
            return RedirectToPage();
        }
    }
}
