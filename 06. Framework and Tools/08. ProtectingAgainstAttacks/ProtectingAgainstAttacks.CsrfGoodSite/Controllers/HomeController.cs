using Microsoft.AspNetCore.Mvc;
using ProtectingAgainstAttacks.CsrfGoodSite.Models;
using System.Diagnostics;

namespace ProtectingAgainstAttacks.CsrfGoodSite.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ICustomerRepository _customerRepository { get; }

    public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
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

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(int customerId)
    {
        Response.Cookies.Append("CustomerId", customerId.ToString(),new CookieOptions
        {
            SameSite = SameSiteMode.Strict
        });
        return RedirectToAction("Emtiaz");
    }

    public IActionResult Emtiaz()
    {
        var customerid = int.Parse(Request.Cookies["CustomerId"]);
        var customer = _customerRepository.GetCustomer(customerid);
        return View(customer);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Transfer(int newCustomerId) 
    {
        var customerid = int.Parse(Request.Cookies["CustomerId"]);
        var customer = _customerRepository.GetCustomer(customerid);
        var Newcustomer = _customerRepository.GetCustomer(newCustomerId);

        var newEmtiaz = customer.Emtiaz + Newcustomer.Emtiaz;
        _customerRepository.SetEmtiaz(customerid, 0);
        _customerRepository.SetEmtiaz(newCustomerId, newEmtiaz);
        return RedirectToAction("Emtiaz");
    }
}
