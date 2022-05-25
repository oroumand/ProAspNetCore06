var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHsts(opts => {
    opts.MaxAge = TimeSpan.FromDays(365);
    opts.IncludeSubDomains = true;
    opts.Preload = true;
});


var app = builder.Build();
if(app.Environment.IsProduction())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.MapGet("/", () => "Hello World!");

app.Run();

