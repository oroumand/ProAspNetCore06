using Microsoft.AspNetCore.Mvc;

namespace AAASamples.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
