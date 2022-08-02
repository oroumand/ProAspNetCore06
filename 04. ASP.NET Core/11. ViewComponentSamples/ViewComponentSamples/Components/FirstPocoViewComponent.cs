using ViewComponentSamples.Models;

namespace ViewComponentSamples.Components;

public class FirstPocoViewComponent
{
    private readonly NewsDbContext _newsDbContext;

    public FirstPocoViewComponent(NewsDbContext newsDbContext)
    {
        _newsDbContext = newsDbContext;
    }

    public string Invoke()
    {
        string newsDescription = _newsDbContext.News.Where(c => c.Id == 3).FirstOrDefault().Description;
        return newsDescription;
    }
}
