using DirectHttpClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DirectHttpClient.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var result = await client.GetStringAsync("/posts");
            var finalResult = JsonConvert.DeserializeObject<List<Post>>(result);
            return Ok(finalResult);
        }
    }
}
