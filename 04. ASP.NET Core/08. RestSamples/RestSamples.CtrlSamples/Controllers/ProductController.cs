using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSamples.CtrlSamples.Models;
using RestSamples.Model;

namespace RestSamples.CtrlSamples.Controllers;
[Route("api/[controller]")]
//[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductDbContext _dbContext;

    public ProductController(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IActionResult> GetAllProducts([FromServices]ProductDbContext dbContext)
    {
        var products = await dbContext.Products.AsNoTracking().Include(c=>c.Brand).ToListAsync();
        foreach (var item in products)
        {
            item.Brand.Products = null;
        }
        return Ok(products);
    }
    [HttpGet("j/{format?}")]
    [FormatFilter]

    [Produces("application/json","application/xml")]

    public async Task<IActionResult> GetAllProductsJson([FromServices] ProductDbContext dbContext)
    {
        var products = await dbContext.Products.AsNoTracking().Include(c => c.Brand).ToListAsync();
        foreach (var item in products)
        {
            item.Brand.Products = null;
        }
        return Ok(products);
    }
    [HttpGet("GetProduct/{id}")]
    public IActionResult GetProduct([FromServices] ProductDbContext dbContext,int id)
    {
        var product = dbContext.Products.Where(c=>c.Id==id).FirstOrDefault();
        if(product==null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost]
    public IActionResult Post([FromBody] AddProductDto product)
    {
        if (ModelState.IsValid)
        {
            var p = product.ToProduct();
            _dbContext.Products.Add(p);
            _dbContext.SaveChanges();

            return Ok(p.Id);
        }
        return BadRequest(ModelState);
    }
    [HttpGet("google")]
    public IActionResult Redirect()
    {
        return Redirect("http://google.com");
    }


    [HttpPatch("{id}")]
    public async Task<Product> PatchSupplier(int id,[FromBody] JsonPatchDocument<Product> patchDoc)
    {
        Product s = await _dbContext.Products.FindAsync(id);
        if (s != null)
        {
            patchDoc.ApplyTo(s);
            await _dbContext.SaveChangesAsync();
        }
        return s;
    }


    [Consumes("application/json")]
    public string SaveProductJson(ProductBindingTarget product)
    {
        return $"JSON: {product.Name}";
    }

    [HttpPost]
    [Consumes("application/xml")]
    public string SaveProductXml(ProductBindingTarget product)
    {
        return $"XML: {product.Name}";
    }


}

//[
//{ "op": "replace", "path": "name", "value": "Name Patched"},
//{ "op": "replace", "path": "description", "value": "Description Patched"},
//]
