var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
