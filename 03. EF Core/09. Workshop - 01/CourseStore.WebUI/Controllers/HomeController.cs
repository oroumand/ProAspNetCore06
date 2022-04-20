using CourseStore.BusinessLogic;
using CourseStore.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseStore.WebUI.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CourseServices _courseServices;

    public HomeController(ILogger<HomeController> logger, CourseServices courseServices)
    {
        _logger = logger;
        _courseServices = courseServices;
    }

    public IActionResult Index()
    {
        var courses = _courseServices.GetAllCourse();
        return View(courses);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
