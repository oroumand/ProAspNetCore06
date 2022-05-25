using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedSqlServerCache(c =>
{
    c.SchemaName = "dbo";
    c.TableName = "DataCache";
    c.ConnectionString = "Server=.;Database=Cache; User Id=sa; Password=1qaz!QAZ";
});

var app = builder.Build();
app.MapGet("/cache", (HttpContext context, IDistributedCache cache) =>
{
    int num01 = 0;
    string NumKey = nameof(num01);

    num01 = int.Parse(cache.GetString(NumKey) ?? "0");
    num01++;
    cache.SetString(NumKey, num01.ToString(), new DistributedCacheEntryOptions
    {
        SlidingExpiration = TimeSpan.FromMinutes(1),

    });

    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    context.Response.WriteAsync($"<h1>{num01}</h1>");

});
app.MapGet("/", () => "Hello World!");

app.Run();
