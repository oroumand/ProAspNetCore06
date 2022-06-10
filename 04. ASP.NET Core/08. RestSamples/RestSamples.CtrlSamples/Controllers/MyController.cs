using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestSamples.CtrlSamples.Controllers;
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    [HttpGet("GetName1")]
    public string GetName()
    {

        return "My name is Alireza Oroumand";
    }
    [HttpGet("GetName2/{id}")]
    public IActionResult GetName2(int id)
    {

        return Ok($"My name is Alireza Oroumand 2 - {id}");
    }
}
