using CourseStore.Model.Tags.Commands;
using CourseStore.Model.Tags.Queries;
using CourseStore.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseStore.WebAPI.Tags;

public class TagsController : BaseController
{
    public TagsController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("CreateTag")]
    public async Task<IActionResult> CreateTag(CreateTag tag)
    {
        var response = await _mediator.Send(tag);
        if(response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }

    [HttpPut("UpdateTag")]
    public async Task<IActionResult> UpdateTag(UpdateTag tag)
    {
        var response = await _mediator.Send(tag);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }


    [HttpGet("FilterByName")]
    public async Task<IActionResult> SearchTag([FromQuery]FilterByName tag)
    {
        var response = await _mediator.Send(tag);
        if (response.IsSuccess)
        {
            return Ok(response.Result);
        }
        return response.IsSuccess ? Ok(response.Result) : BadRequest(response.Errors);
    }
}
