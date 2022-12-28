using HostedServiceSamples.QuartzSamples.Jobs;
using HostedServiceSamples.QuartzSamples.Models;
using Quartz;

namespace HostedServiceSamples.QuartzSamples;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHttpClient<PostService>();
        // Add services to the container.
        builder.Services.AddQuartz(c =>
        {
            c.UseMicrosoftDependencyInjectionJobFactory();
            
            var jobKey = new JobKey("Post To File Job");
            c.AddJob<PostToFileJob>(j=>j.WithIdentity(jobKey));

            c.AddTrigger(t => t.ForJob(jobKey).WithIdentity("Post To File Job Trigger")
            .StartNow().WithSimpleSchedule(sc=>sc.WithInterval(TimeSpan.FromSeconds(5)).WithRepeatCount(3)));

        });
        builder.Services.AddQuartzHostedService(c =>
        {
            c.WaitForJobsToComplete = true;
        });
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
    }
}
