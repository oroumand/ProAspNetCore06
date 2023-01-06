using HostedServiceSamples.PostsToFile.Models;

namespace HostedServiceSamples.PostsToFile;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHttpClient<PostService>();
                services.AddHostedService<Worker>();
            }).UseWindowsService()
            .Build();

        host.Run();
    }
}