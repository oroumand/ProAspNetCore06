using Asp06Store.ShopUI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var cnnString = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(cnnString));
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("pagination", "/{controller=home}/{action=index}/Page{PageNumber}");
            endpoints.MapDefaultControllerRoute();
        }
    );

app.Run();
