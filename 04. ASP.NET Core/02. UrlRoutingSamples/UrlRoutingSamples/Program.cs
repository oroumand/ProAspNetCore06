using UrlRoutingSamples.CustomConstraints;
using UrlRoutingSamples.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("nc",
    typeof(CodeMeliConstraint));
});


var app = builder.Build();
//app.UseMiddleware<MavadeLazem>();
//app.UseMiddleware<TarzeTahie>();

app.UseRouting();

app.UseMiddleware<CheckEndpoint>();
app.UseEndpoints(endpoints =>
{
    //endpoints.MapGet("/mv/Nimroo", new MavadeLazem().InvokeAsync);
    //endpoints.MapGet("/tt/Nimroo", new TarzeTahie().InvokeAsync);
    endpoints.MapGet("/routing", async context =>
     {
         await context.Response.WriteAsync("Routing Endpoint");

     }).WithDisplayName("My Endpiont");
});
//app.MapGet("/test123874749837/{Name}", new MavadeLazem().InvokeAsync).
//    WithMetadata(new RouteNameMetadata("mv"));
//app.MapGet("/tt/{Name}", new TarzeTahie().InvokeAsync);
//app.MapGet("/routing", async context =>
//     {
//         await context.Response.WriteAsync("Routing Endpoint");
//     });

//app.MapGet("/io/{filename}.{extentsion}/t", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }
//});
//app.MapGet("/{Segment01}/{Segmetn02}/{Segment03=ARO}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/{Segment01}/{Segmetn02}/{Segment03?}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/{Segment01}/{Segmetn02}/{Segment03}/{*catchall}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/{Segment01:minlength(2):maxlength(6)}/{Segmetn02:bool}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/cm/{codemelli:nc}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//});
//app.MapGet("/cm/{age:int}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//}).Add(c => ((RouteEndpointBuilder)c).Order = 1);
//app.MapGet("/cm/{price:double}", async context =>
//{
//    var routeDate = context.Request.RouteValues;

//    foreach (var item in routeDate)
//    {
//        await context.Response.WriteAsync($"{item.Key}:{item.Value} {Environment.NewLine}");

//    }

//}).Add(c => ((RouteEndpointBuilder)c).Order = 2);
//app.MapFallback(async context =>
//{
//    await context.Response.WriteAsync($"Fallback works");

//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Terminal Response");
//});

app.Run();
