using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelBindingSamples.Models;

namespace ModelBindingSamples.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly MyModelBindingContext _context;

        public ProductPageModel(MyModelBindingContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Product Product { get; set; }
        public void OnGet()
        {
            Product = _context.Products.Include(c => c.Category).Where(c => c.Id == 1).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            TempData["P"] = Product;
            return RedirectToPage("Result");
        }
    }
}
