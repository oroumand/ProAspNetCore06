var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/cookies",async (HttpContext context) =>
{
    int num01,num02 = 0;
    string num01Key = nameof(num01);
    string num02Key = nameof(num02);
    num01 = int.Parse(context.Request.Cookies[num01Key] ?? "0");
    num02 = int.Parse(context.Request.Cookies[num02Key] ?? "0");
    
    num01++;
    num02++;

    context.Response.Cookies.Append(num01Key, num01.ToString());
    context.Response.Cookies.Append(num02Key, num02.ToString(),new CookieOptions
    {
        Expires = DateTimeOffset.Now.AddSeconds(10),
        IsEssential = true,
        Path = "/cookies"

    });


    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{num01}-{num02}</h1>");
});

app.MapGet("/clear", async context =>
 {
     context.Response.Cookies.Delete("num01");
     context.Response.Cookies.Delete("num02");

 });

app.MapGet("/", () => "Hello World!");

app.Run();
