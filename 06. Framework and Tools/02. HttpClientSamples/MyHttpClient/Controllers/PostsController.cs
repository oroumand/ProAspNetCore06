using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHttpClient.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyHttpClient.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PostsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using (var client = _httpClientFactory.CreateClient("posts"))
        {
            var result = await client.GetStringAsync("/posts");
            var finalResult = JsonConvert.DeserializeObject<List<Post>>(result);
            return Ok(finalResult);
        }
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        using (var client = _httpClientFactory.CreateClient("posts"))
        {
            var result = await client.GetStringAsync($"/posts/{id}");
            var finalResult = JsonConvert.DeserializeObject<Post>(result);
            return Ok(finalResult);
        }
    }
}
