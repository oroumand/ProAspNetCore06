using IdentityModel.Client;
using Newtonsoft.Json;

namespace SsoSamples.Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        var identityClient = new HttpClient();
        var discovery = await identityClient.GetDiscoveryDocumentAsync("https://localhost:7003");
        if(discovery.IsError)
        {
            System.Console.WriteLine(discovery.Error);
            return;
        }
        var tokenResponse = await identityClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = discovery.TokenEndpoint,
            ClientId= "client",
            ClientSecret= "secret",
            Scope= "api1"
        });

        if(tokenResponse.IsError)
        {
            System.Console.WriteLine(tokenResponse.Error);
            return;
        }

        var client = new HttpClient();

        client.BaseAddress = new Uri("https://localhost:7001");
        client.SetBearerToken(tokenResponse.AccessToken);
        var stringResult = await client.GetStringAsync("/WeatherForecast");
        var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(stringResult);
        foreach (var item in result)
        {
            System.Console.WriteLine($"{item.Date}\t {item.Summary} \t\t {item.TemperatureC}\t{item.TemperatureF}");
            System.Console.WriteLine("".PadLeft(200,'-'));
        }
        System.Console.ReadLine();
    }
}
