using ViewComponentSamples.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NewsDbContext>();
var app = builder.Build();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
