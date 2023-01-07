namespace RealTimeWebSamples.Sse.Extensions;

public static class SseExtentsions
{
    public static async Task SsEInitAsync(this HttpContext context)
    {
        context.Response.Headers.Add("Cache-Control", "no-cache");
        context.Response.Headers.Add("Content-Type", "text/event-stream");
        await context.Response.Body.FlushAsync();
    }


    public static async Task SsESendAsync(this HttpContext context, string message)
    {
        foreach (var line in message.Split('\n'))
            await context.Response.WriteAsync("data: " + line + "\n");
        await context.Response.WriteAsync("\n");
        await context.Response.Body.FlushAsync();
    }


}
