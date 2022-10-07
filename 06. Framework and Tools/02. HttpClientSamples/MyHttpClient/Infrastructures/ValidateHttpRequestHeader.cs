using System.Diagnostics;
using System.Net;

namespace MyHttpClient.Infrastructures;

public class ValidateHttpRequestHeader : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
    {
        if (!request.Headers.Contains("X-API-KEY"))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(
                    "You must supply an API key header called X-API-KEY")
            };
        }

        return await base.SendAsync(request, cancellationToken);
    }
}

public class LogHttpRequest : DelegatingHandler
{
    private readonly ILogger<LogHttpRequest> _logger;
    private readonly Stopwatch _stopwatch = new Stopwatch();
    public LogHttpRequest(ILogger<LogHttpRequest> logger)
    {

        _logger = logger;
    }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _stopwatch.Start();
        _logger.LogInformation($"Request sent at {DateTime.Now}");
        var result = base.SendAsync(request, cancellationToken);
        _logger.LogInformation($"Response received at {DateTime.Now}");
        _stopwatch.Stop();
        _logger.LogInformation($"Request total time is {_stopwatch.ElapsedMilliseconds}");

        return result;

    }
}