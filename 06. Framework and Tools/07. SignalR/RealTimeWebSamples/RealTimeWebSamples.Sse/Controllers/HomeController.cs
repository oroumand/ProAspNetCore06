using Microsoft.AspNetCore.Mvc;
using RealTimeWebSamples.Sse.Models;
using System.Diagnostics;
using RealTimeWebSamples.Sse.Extensions;
namespace RealTimeWebSamples.Sse.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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
    [HttpGet("/sse")]
    public async Task SSE()
    {
        await HttpContext.SsEInitAsync();
        int counter = 0;
        do
        {
            await HttpContext.SsESendAsync($"This is message number: {counter}");
            Thread.Sleep(5000);
            counter++;
        } while (counter < 10);
    }
}
