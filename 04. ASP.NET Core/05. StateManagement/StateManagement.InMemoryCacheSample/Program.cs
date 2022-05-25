using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();


var app = builder.Build();

app.MapGet("/cache", (HttpContext context, IMemoryCache cache) =>
{
    int num01 = 0;
    string NumKey = nameof(num01);

    num01 = cache.Get<int>(NumKey);
    num01++;
    cache.Set(NumKey, num01, new MemoryCacheEntryOptions
    {
        //AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30),
        SlidingExpiration = TimeSpan.FromMinutes(1),
        
    });

    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    context.Response.WriteAsync($"<h1>{num01}</h1>");

});
app.MapGet("/", () => "Hello World!");

app.Run();
