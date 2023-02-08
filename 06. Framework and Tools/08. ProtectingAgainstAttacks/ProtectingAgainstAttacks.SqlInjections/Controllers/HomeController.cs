using Microsoft.AspNetCore.Mvc;
using ProtectingAgainstAttacks.SqlInjections.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ProtectingAgainstAttacks.SqlInjections.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string searchText = "Oroumand")
    {
        string SqlQuery = $"Select Id, LastName from People where LastName = N'{searchText}'";
        string cnnString = "Server=.; Initial catalog=NewsDb; User Id=sa; Password=1qaz!QAZ";
        SqlConnection cnn = new SqlConnection(cnnString);
        SqlCommand cmd = cnn.CreateCommand();
        cmd.CommandText = SqlQuery;
        cnn.Open();
        var reader = cmd.ExecuteReader();

        return View(reader);
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
