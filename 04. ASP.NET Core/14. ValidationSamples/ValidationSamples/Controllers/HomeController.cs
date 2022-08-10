using Microsoft.AspNetCore.Mvc;

namespace ValidationSamples.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
