using CourseStore.Model.Framework;
using CourseStore.Model.Tags.Entities;

namespace CourseStore.Model.Courses.Entities;

public class CourseTag:BaseEntity
{
    public int CourseId { get; set; }
    public int TagId { get; set; }
    public Course Course { get; set; }
    public Tag Tag { get; set; }
}