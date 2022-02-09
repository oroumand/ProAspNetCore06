using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationConfiguraitonSample.SimpleConventionSample;
public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public List<Tag> Tags { get; set; }

}

public class Tag
{
    public int Id { get; set; }
    public string TagName { get; set; }
    public List<Post> Posts { get; set; }
}


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Discount Discount { get; set; }
}

public class Discount
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
}