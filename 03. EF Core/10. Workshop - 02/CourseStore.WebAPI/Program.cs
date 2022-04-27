using CourseStore.DAL.Contexts;
using CourseStore.DAL.Framework;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CourseStore.BLL.Tags.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CourseStoreDbContext>(c=> c.UseSqlServer("Server=.; Initial Catalog=CleanCourse; User Id=sa; Password=1qaz!QAZ").
    AddInterceptors(new AddAuditFieldInterceptor()));

builder.Services.AddMediatR(typeof(CreateTagHandler).Assembly);

builder.Services.AddControllers();
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
