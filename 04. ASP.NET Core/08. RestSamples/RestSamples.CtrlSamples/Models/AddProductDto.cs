using RestSamples.Model;
using System.ComponentModel.DataAnnotations;

namespace RestSamples.CtrlSamples.Models;

public class AddProductDto
{
    [Required]
    [MinLength(5)]
    public string Name { get; set; }
    [MinLength(20)]

    public string Description { get; set; }
    public int Price { get; set; }
    public int BrandId { get; set; }

    public Product ToProduct() => new Product
    {
        Name = Name,
        Description = Description,
        Price = Price,
        BrandId = BrandId

    };
}
