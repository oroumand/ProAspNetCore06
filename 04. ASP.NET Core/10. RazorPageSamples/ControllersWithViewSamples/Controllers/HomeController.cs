using ControllersWithViewSamples.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersWithViewSamples.Controllers;
public class HomeController : Controller
{
    private readonly PeopleContext _peopleContext;

    public HomeController(PeopleContext peopleContext)
    {
        _peopleContext = peopleContext;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }
    public IActionResult Jsample()
    {
        return View(_peopleContext.People.ToList());
    }
    public IActionResult HSample()
    {
        string myHtml = "<h1>Sample Text</h1>";
        return View("HSample",myHtml);
    }
}
