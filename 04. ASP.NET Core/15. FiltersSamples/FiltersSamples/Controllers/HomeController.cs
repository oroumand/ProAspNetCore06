using FiltersSamples.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FiltersSamples.Controllers;
//[RequireHttps]
//[MyHttps]
[FilterOrder("Controller 01")]
[FilterOrder("Controller 02")]
public class HomeController : Controller
{
    //[ActionTimer]
    // [ResultTimer]

    //[Guid("FirstGuid")]
    //[Guid("SeccondGuid")]

    //[TypeFilter(typeof(DiFillterAttribute))]

    //[ServiceFilter(typeof(MyGuidAttribute))]
    //[ServiceFilter(typeof(MyGuidAttribute))]

    [FilterOrder("Action 01",Order =10)]
    [FilterOrder("Action 02", Order = 5)]
    [FilterOrder("Action 03", Order =11)]
    [FilterOrder("Action 04", Order = 20)]
    [FilterOrder("Action 05", Order = 0)]
    public IActionResult Index(string temp = "aaa")
    {
        return View();
    }
    //[RequireHttps]
    public IActionResult About()
    {
        return View();
    }

    [MyCache]

    public IActionResult CacheSample()
    {
        return View(DateTime.Now);
    }
}
