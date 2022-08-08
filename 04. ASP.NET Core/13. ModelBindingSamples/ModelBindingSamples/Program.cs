using Microsoft.EntityFrameworkCore;
using ModelBindingSamples.Models;
using static ModelBindingSamples.Infrastructures.MyModelBinder;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyModelBindingContext>(c => c.UseSqlServer("Server=.; Initial Catalog=MBDb;User Id=sa; Password=1qaz!QAZ"));
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new CustomeBinderProvider());
});

builder.Services.AddRazorPages();
var app = builder.Build();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Run();
