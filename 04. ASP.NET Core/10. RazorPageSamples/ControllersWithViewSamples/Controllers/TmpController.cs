using Microsoft.AspNetCore.Mvc;

namespace ControllersWithViewSamples.Controllers;
public class TmpController : Controller
{
    public IActionResult Index()
    {
        TempData["UserName"] = "Alireza Oroumand";
        return RedirectToAction("Redirected");
    }

    public IActionResult Redirected()
    {
        //TempData.Keep();
        //var userName = TempData.Peek("UserName");
        var userName = TempData["UserName"];
        TempData.Keep("UserName");


        return View(userName);
    }
}
