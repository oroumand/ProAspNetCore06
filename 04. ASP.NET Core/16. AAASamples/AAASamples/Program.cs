using AAASamples.Infra;
using AAASamples.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AAADbContext>(c => c.UseSqlServer("Server=.; Initial Catalog=AAADb; User ID=sa; Password=1qaz!QAZ"));
builder.Services.AddIdentity<CostumIdentityUser, IdentityRole>(c =>
{
    //c.Password.RequiredLength = 4;
    //c.Password.RequiredUniqueChars = 2;
    //c.Password.RequireNonAlphanumeric = false;
    //c.Password.RequireUppercase = false;
    //c.Password.RequireLowercase= false;
    //c.Password.RequireDigit = false;
    c.User.AllowedUserNameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
    c.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AAADbContext>().AddUserValidator<CustomUserValidator>();
//.AddPasswordValidator<BlackListPasswordValidator<IdentityUser>>();

//builder.Services.Configure<IdentityOptions>(c =>
//{

//});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
