using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHttpClient.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyHttpClient.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsTypedController : ControllerBase
{
    private readonly PostService _postService;

    public PostsTypedController(PostService postService)
    {
        _postService = postService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _postService.GetAll());
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _postService.GetById(id));
    }
}
