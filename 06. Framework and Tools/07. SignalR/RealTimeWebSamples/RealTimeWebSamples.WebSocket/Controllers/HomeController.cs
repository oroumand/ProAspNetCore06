using Microsoft.AspNetCore.Mvc;
using RealTimeWebSamples.WebSockets.Models;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;

namespace RealTimeWebSamples.WebSockets.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    public async void CountUntil(int id)
    {
        var context = _httpContextAccessor.HttpContext;
        if (context.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            for (int i = 0; i < id; i++)
            {
                Thread.Sleep(1000);
                var jsonMessage = $"\"{i}\"";
                await webSocket.SendAsync(buffer: new ArraySegment<byte>(
                        array: Encoding.ASCII.GetBytes(jsonMessage),
                        offset: 0,
                        count: jsonMessage.Length),
                    messageType: WebSocketMessageType.Text,
                    endOfMessage: true,
                    cancellationToken: CancellationToken.None);
            }
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure,
                "Done", CancellationToken.None);
        }
        else
        {
            context.Response.StatusCode = 400;
        }
    }
}

