using GrpcSamples.Web.Interceptors;
using GrpcSamples.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
    options.Interceptors.Add<ExceptionInterceptor>();
});
builder.Services.AddGrpcReflection();

var app = builder.Build();
app.MapGrpcReflectionService();
// Configure the HTTP request pipeline.
app.MapGrpcService<PersonGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
