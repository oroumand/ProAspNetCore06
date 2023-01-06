using HostedServiceSamples.PostsSample.Infrastructures;
using HostedServiceSamples.PostsSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace HostedServiceSamples.PostsSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly PostService _postService;
    private readonly PostCache _postCache;

    public PostsController(PostService postService, PostCache postCache,IServiceProvider serviceProvider)
    {
        _postService = postService;
        _postCache = postCache;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_postCache.Get());
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _postService.GetById(id));
    }
}
