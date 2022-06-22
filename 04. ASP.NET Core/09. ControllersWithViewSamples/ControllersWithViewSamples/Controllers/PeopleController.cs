using ControllersWithViewSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllersWithViewSamples.Controllers;
public class PeopleController : Controller
{
    private readonly PeopleContext _peopleContext;

    public PeopleController(PeopleContext peopleContext)
    {
        _peopleContext = peopleContext;
    }
    [HttpGet]
    public IActionResult GetAllPeople()
    {        
        return View(_peopleContext.People.ToList());
    }

    public IActionResult Exps()
    {
        return View();
    }

    public IActionResult ViewBagSample()
    {
        ViewBag.Title = "Test Viewbag";
        return View();
    }

}
