using IntroductionToAspNetCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IntroductionToAspNetCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonContext personContext;

        public HomeController(ILogger<HomeController> logger, PersonContext personContext)
        {
            _logger = logger;
            this.personContext = personContext;
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Person person)
        {
            personContext.People.Add(person);
            personContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}