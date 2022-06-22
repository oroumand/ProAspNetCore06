using ControllersWithViewSamples.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();//.AddSessionStateTempDataProvider();
builder.Services.AddScoped<IRepository,MyRepository>();
builder.Services.AddDbContext<PeopleContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("PeopleDbCnn")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllerRoute("Default", "{controller=Tmp}/{action=index}/{id?}");
app.MapDefaultControllerRoute();

app.Run();
