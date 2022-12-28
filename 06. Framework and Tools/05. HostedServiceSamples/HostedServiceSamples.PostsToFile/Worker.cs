using HostedServiceSamples.PostsToFile.Models;
using Newtonsoft.Json;

namespace HostedServiceSamples.PostsToFile;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var postService = scope.ServiceProvider.GetRequiredService<PostService>();
                var posts = await postService.GetAll();
                System.IO.File.WriteAllText($"F:\\Temp\\{DateTime.Now.Ticks}.json", JsonConvert.SerializeObject(posts));
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
                _logger.LogInformation("Total post count: {count}", posts.Count);

            }
        }
    }
}
