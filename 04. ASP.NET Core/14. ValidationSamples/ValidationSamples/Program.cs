using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationSamples.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<MvcOptions>(options =>
{
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(c => "مقدار این ویژگی صحیح نمی‌باشد");
});
builder.Services.AddDbContext<ValidationDbContext>(c => c.UseSqlServer("Server=.; Initial Catalog=ValidationDb; User Id=sa; Password=1qaz!QAZ"));
var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
