using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSamples.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult IntInput(int id)
    {

        return View(id);
    }
    public IActionResult StrInput(string id)
    {

        return Json(id);
    }
    public IActionResult BoolInput(bool id)
    {
        return View(id);
    }

    public IActionResult Collection()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Collection(List<string> Data)
    {
        return Json(Data);
    }

    public IActionResult AcceptHeader([FromHeader]string accept)
    {
        return Json(accept);
    }
    public IActionResult AcceptEnHeader([FromHeader(Name = "accept-encoding")] string acceptEncoding)
    {
        return Json(acceptEncoding);
    }
   
}
