
using ConfigurationSamples.Options;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets("dadfe875-bea7-49a7-a7e4-0e28cc8062e1");
//builder.Services.Configure<LocationOptions>(c =>
//{
//    c.Province = "Fars";
//    c.City = "Shiraz";
//});

builder.Services.Configure<LocationOptions>(builder.Configuration.GetSection("Location"));


CourseOption courseOption = new CourseOption();
builder.Configuration.GetSection("Course").Bind(courseOption);
builder.Services.AddSingleton<CourseOption>(courseOption);

//builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("appsettings.Alireza.json", true, true);
//builder.Configuration.AddKeyPerFile(@"F:\Source\MyConfigs");

//var city = builder.Configuration["Location:Province"];

var app = builder.Build();
app.MapGet("/us", async (HttpContext context, IConfiguration configs) =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{configs["MyUserName"]} - {configs["MyPassword"]} </h1>");
});


app.MapGet("/ioption1", async (HttpContext context, IOptions<LocationOptions> locationOption) =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{locationOption.Value.Province} - {locationOption.Value.City} </h1>");
});

app.MapGet("/ioption2", async (HttpContext context, CourseOption courseOptions) =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{courseOptions.CourseName} - {courseOptions.TeacherName} </h1>");
});

app.MapGet("/userName", async (HttpContext context, IConfiguration IConfiguration) =>
 {
     var userName = IConfiguration["CustomerName"];
     context.Response.StatusCode = 200;
     context.Response.ContentType = "text/html";
     await context.Response.WriteAsync($"<h1>{userName}</h1>");
 });
app.MapGet("/city", async (HttpContext context, IConfiguration IConfiguration) =>
{
    var city = IConfiguration["Location:Province"];
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{city}</h1>");
});

app.MapGet("/section", async (HttpContext context, IConfiguration IConfiguration) =>
{
    var locationSectionConfig = IConfiguration.GetSection("Location");
    var city = locationSectionConfig["City"];
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{city}</h1>");
});

app.MapGet("/sectionlog", async (HttpContext context, IConfiguration IConfiguration) =>
{
    var locationSectionConfig = IConfiguration.GetSection("Logging:LogLevel");
    var defaultLogLevel = locationSectionConfig["Default"];
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($"<h1>{defaultLogLevel}</h1>");
});
app.MapGet("/", () => "Hello World!");

app.Run();
