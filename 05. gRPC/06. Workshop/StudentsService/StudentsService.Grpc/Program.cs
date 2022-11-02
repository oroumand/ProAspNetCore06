using StudentsService.BLL.Services;
using StudentsService.DAL;
using StudentsService.DAL.Repositories;
using StudentsService.Domain.Repositories;
using StudentsService.Domain.Services;
using StudentsService.Grpc.Infrastructures;
using StudentsService.Grpc.Interceptors;
using StudentsService.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddDbContext<StudentContext>();
builder.Services.AddSingleton<ProtoFileProvider>();
builder.Services.AddGrpc(c =>
{
    c.EnableDetailedErrors = true;
    c.Interceptors.Add<ExceptionInterceptor>();
});

builder.Services.AddGrpcReflection();



var app = builder.Build();
app.MapGrpcReflectionService();
// Configure the HTTP request pipeline.
app.MapGrpcService<StudentsService.Grpc.Services.v1.StudentService>();

app.MapGet("/protos", (ProtoFileProvider protoFileProvider) =>
{
    return Results.Ok(protoFileProvider.GetAll());
});
app.MapGet("/protos/v{version:int}/{protoName}", (ProtoFileProvider protoFileProvider, int version, string protoName) =>
{
    string filePath = protoFileProvider.GetPath(version, protoName);
    if (string.IsNullOrEmpty(filePath))
        return Results.NotFound();
    return Results.File(filePath);
});

app.MapGet("/protos/v{version:int}/{protoName}/view", async (ProtoFileProvider protoFileProvider, int version, string protoName) =>
{
    string fileContent = await protoFileProvider.GetContent(version, protoName);
    if (string.IsNullOrEmpty(fileContent))
        return Results.NotFound();
    return Results.Text(fileContent);
});
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
