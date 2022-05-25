using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseStaticFiles();
//app.UseStaticFiles("/staticFiles");
var rootPath = $"{app.Environment.ContentRootPath}\\MyFiles" ;
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider= new PhysicalFileProvider(rootPath),    
});
app.MapGet("/", () => "Hello World!");

app.Run();
