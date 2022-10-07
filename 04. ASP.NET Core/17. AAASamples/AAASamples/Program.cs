using AAASamples.Infra;
using AAASamples.Models;
using AAASamples.Requirmens;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddRazorPages();

//builder.Services.Configure<CookieAuthenticationOptions>(
//IdentityConstants.ApplicationScheme,
//opts => {
//    opts.LoginPath = "/Authenticate";
//    opts.AccessDeniedPath = "/NotAllowed";

//});
builder.Services.AddSingleton<IAuthorizationHandler, AgePolicyRequirementHandler>();
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

builder.Services.AddAuthorization(c =>
{
    c.AddPolicy("IsAdmin", pb =>
    {
        pb.RequireRole("Admin").RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "alireza", "hamid");
    });
    c.AddPolicy("IsMoreThan18Years", pb =>
    {
        pb.Requirements.Add(new AgePolicyRequirement(18));
        pb.Requirements.Add(new AgePolicyRequirement(18));
    });
});
//.AddPasswordValidator<BlackListPasswordValidator<IdentityUser>>();

//builder.Services.Configure<IdentityOptions>(c =>
//{

//});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
