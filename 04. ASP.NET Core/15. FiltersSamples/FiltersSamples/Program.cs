using FiltersSamples.Filters;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddMvcOptions(c =>
{
    c.Filters.Add(new FilterOrderAttribute("Global Filter"));
});

builder.Services.AddScoped<MyGuidAttribute>();


builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStatusCodePages();
app.UseStaticFiles();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.Run();
