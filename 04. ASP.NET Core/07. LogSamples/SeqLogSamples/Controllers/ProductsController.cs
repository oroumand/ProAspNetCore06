using Microsoft.AspNetCore.Mvc;

namespace LogSamples.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger,ILoggerFactory loggerFactory)
    {
        _logger = logger;
    }
    [HttpGet("/Product")]
    public IActionResult GetProduct(int id)
    {
        _logger.BeginScope("My Scope", new
        {
            Name = "Alireza",
            LastName = "Oroumand"
        });

        _logger.LogInformation("Request for product with id:{ID} responsed", id);

        return Ok(new
        {
            Id = id,
            ProductName = $"Product {id}"
        });
    }
}
