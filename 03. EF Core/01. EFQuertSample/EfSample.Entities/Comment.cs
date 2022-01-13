namespace EfSample.Entities;

public class Comment
{
    public int CommentId { get; set; }
    public int CourseId { get;  set; }
    public Course Course { get; set; }
    public string CommentBy { get; set; }
    public string CommentText { get; set; }
    public int StarCount { get; set; }
    public bool IsApproved { get; set; }
}