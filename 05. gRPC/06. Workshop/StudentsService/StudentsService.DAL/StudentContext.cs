using Microsoft.EntityFrameworkCore;
using StudentsService.DAL.Entities;

namespace StudentsService.DAL;
public class StudentContext:DbContext
{
    public DbSet<Student> Students{ get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=StudentDb; User Id=sa; Password=1qaz!QAZ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Student>().HasMany(c => c.PhoneNumbers).WithOne().OnDelete(DeleteBehavior.Cascade);
    }

}
