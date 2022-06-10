using Newtonsoft.Json;
using RestSamples.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>();
var app = builder.Build();
app.MapGet("/GetProductList",async (HttpContext context, ProductDbContext dbContext) =>
 {
     var productList = dbContext.Products.ToList();

     var productListString = JsonConvert.SerializeObject(productList);


     context.Response.StatusCode = 200;

     await context.Response.WriteAsync(productListString);
 });
app.MapGet("/", () => "Hello World!");

app.Run();
