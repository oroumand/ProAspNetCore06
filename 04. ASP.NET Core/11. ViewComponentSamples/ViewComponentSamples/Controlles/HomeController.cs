using Microsoft.AspNetCore.Mvc;

namespace ViewComponentSamples.Controlles;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult News()
    {
        return View();
    }
}
