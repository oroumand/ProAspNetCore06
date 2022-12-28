using HostedServiceSamples.PostsSample.Models;
using Microsoft.AspNetCore.Components;

namespace HostedServiceSamples.PostsSample.Infrastructures;

public class PostCacheHostedService : BackgroundService
{
    private readonly PostCache _postCache;
    private readonly IServiceProvider _serviceProvider;

    public PostCacheHostedService(PostCache postCache,IServiceProvider serviceProvider)
    {
        _postCache = postCache;
        _serviceProvider = serviceProvider;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var fakeService = scope.ServiceProvider.GetRequiredService<IFakeService>();
                var postService = scope.ServiceProvider.GetRequiredService<PostService>();
                var getTrue = fakeService.GetTrue();
                var posts = await postService.GetAll();
                _postCache.Set(posts);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }


        }
    }
}
