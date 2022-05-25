var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(new DeveloperExceptionPageOptions
    {
        SourceCodeLineCount = 8,
    });
}
else if(app.Environment.IsProduction())
{
    app.UseExceptionHandler("/exh.html");
}
app.UseStaticFiles();
app.MapGet("/ex", () =>
{
    throw new Exception("Exeption in my applicaiton");
});
app.MapGet("/", () => "Hello World!");

app.Run();
