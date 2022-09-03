using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersSamples.Filters;

public class CacheItem
{
    public DateTime CreateDate { get; set; }
    public IActionResult Result { get; set; }
}
public class MyCacheAttribute : Attribute, IResourceFilter
{

    public  Dictionary<string, CacheItem> Caches { get; set; } = new Dictionary<string, CacheItem>();

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        if (!Caches.ContainsKey(context.HttpContext.Request.Path))
        {
            Caches[context.HttpContext.Request.Path] = new CacheItem
            {
                CreateDate = DateTime.Now,
                Result = context.Result
            };
        }
        
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (Caches.ContainsKey(context.HttpContext.Request.Path))
        {
            var item = Caches[context.HttpContext.Request.Path];
            if (DateTime.Now.AddSeconds(-10) <= item.CreateDate)
            {
                context.Result = item.Result;
            }
            else
            {
                Caches.Remove(context.HttpContext.Request.Path);
            }
        }
    }
}
