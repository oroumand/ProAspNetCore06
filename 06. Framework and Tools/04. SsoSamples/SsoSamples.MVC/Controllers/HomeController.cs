using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SsoSamples.MVC.Models;
using System.Diagnostics;

namespace SsoSamples.MVC.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _client;
    public HomeController(ILogger<HomeController> logger,IHttpClientFactory factory)
    {
        _client = factory.CreateClient("w");
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        var resutlString = await _client.GetStringAsync("/WeatherForecast");

        var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(resutlString);
        return View(result);
    }
    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
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
