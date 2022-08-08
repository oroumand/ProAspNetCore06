using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelBindingSamples.Models;

namespace ModelBindingSamples.Controllers;
public class ProductsController : Controller
{
    private readonly MyModelBindingContext _context;

    public ProductsController(MyModelBindingContext context)
    {
        _context = context;
    }
    public IActionResult Index(int? id)
    {
        if (id.HasValue)
        {
            var p = _context.Products.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefault();
            return View(p);
        }
        else
        {
            return View("InvalidId");
        }
    }

    public IActionResult Save(int id=1)
    {
        var p = _context.Products.Include(c => c.Category).Where(c => c.Id == id).FirstOrDefault();
        return View(p);
    }
    [HttpPost]
    //public IActionResult Save([Bind("Name")] Product input)
    public IActionResult Save(Product input)
    {
        return View("Result", input);
    }

    [HttpPost]

    public async Task<IActionResult> SaveManual()
    {
        Product input = new Product();
        await TryUpdateModelAsync<Product>(input);
        return View("Result", input);
    }

    public IActionResult SaveCategory([Bind(Prefix = "Category.AAA")]Temp myTempValue)
    {
        return Json(myTempValue);
    }
}
