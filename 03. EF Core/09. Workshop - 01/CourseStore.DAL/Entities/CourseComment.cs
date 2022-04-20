namespace CourseStore.DAL.Entities;

public class CourseComment:BaseEntity
{
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public string CommentBy { get; set; }
    public DateTime CommantDate { get; set; }
    public bool IsValid { get; set; }
    public string Comment { get; set; }
}
