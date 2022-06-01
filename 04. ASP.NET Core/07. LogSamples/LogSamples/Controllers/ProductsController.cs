using Microsoft.AspNetCore.Mvc;

namespace LogSamples.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly ILogger _logger2;

    public ProductsController(ILogger<ProductsController> logger,ILoggerFactory loggerFactory)
    {
        _logger = logger;
        _logger2 = loggerFactory.CreateLogger("ProductComponents");
    }
    [HttpGet("/Product")]
    public IActionResult GetProduct(int id)
    {
        _logger.LogInformation("Request for product with id:{ID} responsed", id);
        _logger2.LogInformation("Request for product with id:{ID} responsed", id);



        return Ok(new
        {
            Id = id,
            ProductName = $"Product {id}"
        });
    }
}
