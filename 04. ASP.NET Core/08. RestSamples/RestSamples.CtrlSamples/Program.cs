using Microsoft.AspNetCore.Mvc;
using RestSamples.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>();

builder.Services.AddControllers().AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
//builder.Services.Configure<JsonOptions>(c =>
//{
//    c.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
//});

builder.Services.Configure<MvcNewtonsoftJsonOptions>(c =>
{
    c.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
});

builder.Services.Configure<MvcOptions>(opts => {
    opts.RespectBrowserAcceptHeader = true;
    opts.ReturnHttpNotAcceptable = true;
});

var app = builder.Build();

app.MapControllers();

app.Run();
