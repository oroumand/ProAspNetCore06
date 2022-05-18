using DependencyInjectionSample.DI;
using DependencyInjectionSample.Factory;
using DependencyInjectionSample.SampleMiddleware;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ISingletoneDependency, SingletoneDependency>();
builder.Services.AddSingleton<ISingletoneDependency2, SingletoneDependency2>();
builder.Services.AddTransient<ITransientDependency,TransientDependency>();
builder.Services.AddScoped<IScopeDependency,ScopeDependency>();
builder.Services.AddSingleton<ConcreatSingleton>();

//builder.Services.AddScoped<TestMiddlewareWithInjectino>();

//builder.Services.AddScoped<IMyFactorySample>(c =>
//{
//    bool isOdd = DateTime.Now.Second % 2 != 0;

//    if (isOdd)
//    {
//        return new MyFirstFactory();
//    }
//    return new MySecondFactory();
//});

builder.Services.AddScoped<IMyFactorySample, MyFirstFactory>();
//builder.Services.TryAddScoped<IMyFactorySample, MySecondFactory>();
builder.Services.AddScoped<IMyFactorySample, MySecondFactory>();

var app = builder.Build();
//app.UseMiddleware<TestMiddlewareWithInjectino>();
//app.UseMiddleware<TestMiddleware>();
app.MapGet("/singleton", async (HttpContext context, ISingletoneDependency singleton01, ISingletoneDependency singleton02) =>
{
    await context.Response.WriteAsync($"{singleton01.GetGuid()} --- {singleton02.GetGuid()}");
});

app.MapGet("/transient", async (HttpContext context, ITransientDependency transient01, ITransientDependency transient02) =>
{
    await context.Response.WriteAsync($"{transient01.GetGuid()} --- {transient02.GetGuid()}");
});

app.MapGet("/scope", async (HttpContext context, IScopeDependency scope01, IScopeDependency scope02,IServiceScopeFactory serviceScopeFactory) =>
{
    await context.Response.WriteAsync($"{scope01.GetGuid()} --- {scope02.GetGuid()}");

    var scopProvider = serviceScopeFactory.CreateScope();
    var scopeDependency01 = scopProvider.ServiceProvider.GetService<IScopeDependency>();
    var scopeDependency02 = scopProvider.ServiceProvider.GetService<IScopeDependency>();

    await context.Response.WriteAsync($"**** {scopeDependency01.GetGuid()} --- {scopeDependency02.GetGuid()}");


});
app.MapGet("/factory", async (HttpContext context, IMyFactorySample factory) =>
{
    await context.Response.WriteAsync($"{factory.GetText()}");
});
app.MapGet("/factorylst", async (HttpContext context, IEnumerable<IMyFactorySample> factory) =>
{
    foreach (var item in factory)
    {
        await context.Response.WriteAsync($"{item.GetText()}");

    }
});
app.MapGet("/conc", async (HttpContext context, ConcreatSingleton singleton) =>
{
    await context.Response.WriteAsync($"{singleton.GetGuid()}");
});
app.MapGet("/", () => "Hello World!");

app.Run();
