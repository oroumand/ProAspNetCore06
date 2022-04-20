namespace CourseStore.DAL.Entities;

public class Tag:BaseEntity
{
    public string TagName { get; set; }
    public List<Course> Courses { get; set; }
}
