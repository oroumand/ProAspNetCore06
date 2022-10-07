using Microsoft.AspNetCore.Mvc;

namespace AAASamples.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        var a = User.Identities;
        return View();
    }
}
