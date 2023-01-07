using Microsoft.AspNetCore.Mvc;

namespace RealTimeWebSamples.Ajax.Controllers;

public class Tweet
{
    public string SenderName { get; set; }
    public string Message { get; set; }
}
public class DataController : Controller
{
    public IActionResult Index()
    {
        return Ok(new List<Tweet>
        {
            new Tweet
            {
                SenderName="Alrieza",
                Message="First Tweet Of Alrieza"
            },
            new Tweet
            {
                SenderName="Omid",
                Message="First Tweet Of Omid"
            },
            new Tweet
            {
                SenderName="Mohammad",
                Message="First Tweet Of Mohammad"
            }
        });
    }
}
