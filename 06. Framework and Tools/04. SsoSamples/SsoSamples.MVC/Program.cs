using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace SsoSamples.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
        builder.Services.AddAuthentication(c =>
        {
            c.DefaultScheme = "Cookies";
            c.DefaultChallengeScheme = "oidc";
        }).AddCookie("Cookies")
        .AddOpenIdConnect("oidc", c =>
        {
            c.Authority= "https://localhost:7003";
            c.ClientId = "web";
            c.ClientSecret = "secret";
            c.ResponseType = "code";
            c.Scope.Clear();
            c.Scope.Add("openid");
            c.Scope.Add("profile");
            c.Scope.Add("api1");
            c.Scope.Add("offline_access");
            c.GetClaimsFromUserInfoEndpoint = true;
            c.SaveTokens = true;
        });
        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddHttpClient("w", c =>
        {
            c.BaseAddress = new Uri("https://localhost:7001");
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();

        app.Run();
    }
}