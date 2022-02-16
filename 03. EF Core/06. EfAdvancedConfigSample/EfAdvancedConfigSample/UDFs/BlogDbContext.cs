using Microsoft.EntityFrameworkCore;

namespace EfAdvancedConfigSample.UDFs;

public class BlogDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=BlogDb;User Id=sa; Password=1qaz!QAZ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(p => p.Blog);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post);


        modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod("BlogCommentCount", new[] { typeof(int) })).HasName("CommentedPostCountForBlog");

        modelBuilder.HasDbFunction(typeof(BlogDbContext).GetMethod("PostsWithPopularComments", new[] { typeof(int) }));
        //modelBuilder.HasDbFunction(() => BlogDbContext.BlogCommentCount(default));

    }

    //[DbFunction]
    public static int BlogCommentCount(int blogId)
    {
        throw new NotImplementedException();
    }


    public IQueryable<Post> PostsWithPopularComments(int likeThreshold)
            => FromExpression(() => PostsWithPopularComments(likeThreshold));
}