using Microsoft.AspNetCore.Mvc;
using ProtectingAgainstAttacks.DataprotectionSamples.Models;
using System.Diagnostics;

namespace ProtectingAgainstAttacks.DataprotectionSamples.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyEncryptor _myEncryptor;

    public HomeController(ILogger<HomeController> logger, MyEncryptor myEncryptor)
    {
        _logger = logger;
        _myEncryptor = myEncryptor;
    }

    public IActionResult Index()
    {
        var protectedText = _myEncryptor.Protect("My Name is Alireza Oroumand"); 
        var planeText = _myEncryptor.Unprotect(protectedText);
        return View();
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
