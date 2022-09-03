using FiltersSamples.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiltersSamples.Pages
{
    [MyHttps]
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
