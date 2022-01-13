namespace EfSample.Entities;

public class Tag
{
    public int TagId { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
}