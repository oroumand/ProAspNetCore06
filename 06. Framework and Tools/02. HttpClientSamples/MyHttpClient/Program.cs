using Microsoft.Extensions.DependencyInjection;
using MyHttpClient.Infrastructures;
using MyHttpClient.Models;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<LogHttpRequest>();
builder.Services.AddHttpClient("posts", client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

})
.AddTransientHttpErrorPolicy(policy =>
policy.WaitAndRetryAsync(new[] {
TimeSpan.FromMilliseconds(200),
TimeSpan.FromMilliseconds(500),
TimeSpan.FromSeconds(1)})
)
    .AddHttpMessageHandler<LogHttpRequest>();

//builder.Services.AddHttpClient<PostService>(client =>
//{
//    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

//});

builder.Services.AddHttpClient<PostService>().AddHttpMessageHandler<LogHttpRequest>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
