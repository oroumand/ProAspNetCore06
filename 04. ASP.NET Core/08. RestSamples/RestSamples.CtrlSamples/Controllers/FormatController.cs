using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestSamples.CtrlSamples.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FormatController : ControllerBase
{
    [HttpGet("str")]
    public string GetStr()
    {
        return "Hello World";
    }
    [HttpGet("int")]

    public int GetInt() => 1;
    [HttpGet("obj")]

    public Object GetObject() => new
    {
        FirstName = "Alireza",
        LastName = "Oroumand"
    };
}
