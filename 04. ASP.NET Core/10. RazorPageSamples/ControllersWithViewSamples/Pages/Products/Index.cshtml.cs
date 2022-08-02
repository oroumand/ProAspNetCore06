using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControllersWithViewSamples.Pages.Products
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet(bool nf=false)
        {
            if(nf)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
