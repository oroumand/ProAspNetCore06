using Microsoft.AspNetCore.Mvc;
using ViewComponentSamples.Models;

namespace ViewComponentSamples.Components;

public class FirstBase:ViewComponent
{
    private readonly NewsDbContext _newsDbContext;

    public FirstBase(NewsDbContext newsDbContext)
    {
        _newsDbContext = newsDbContext;
    }
    public string Invoke()
    {       
        var description = _newsDbContext.News.Where(c => c.Id == 4).First().Description;
        return description;
    }
}
