using StateManagement.Session.HelperClass;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(c =>
{
    c.IdleTimeout = TimeSpan.FromSeconds(10);
});
var app = builder.Build();


app.UseSession();
app.MapGet("/sessionId", (HttpContext context) =>
{

    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    context.Response.WriteAsync($"<h1>{context.Session.Id}</h1>");

});
app.MapGet("/clear", (HttpContext context) =>
{
    context.Session.Clear();

    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    context.Response.WriteAsync($"<h1>Clear Session</h1>");

});
app.MapGet("/session", (HttpContext context) =>
{
    int num01 = 0;
    string NumKey = nameof(num01);
    num01 = context.Session.GetInt32(NumKey) ?? 0;
    num01++;
    context.Session.SetInt32(NumKey, num01);

    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    context.Response.WriteAsync($"<h1>{num01}</h1>");

});
app.MapGet("/", () => "Hello World!");

app.Run();
