using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ViewComponentSamples.Models;

namespace ViewComponentSamples.Components;

public class NewsList:ViewComponent
{
    private readonly NewsDbContext _newsDbContext;

    //[ViewComponentContext]
    //public ViewComponentContext ViewComponentContext { get; set; }
    public NewsList(NewsDbContext newsDbContext)
    {
        _newsDbContext = newsDbContext;
    }

    public IViewComponentResult Invoke(string viewName)
    {

        var newsList = _newsDbContext.News.ToList();
        return View(viewName, newsList);
    }
}
