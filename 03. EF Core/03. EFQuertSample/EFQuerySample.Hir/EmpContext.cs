using Microsoft.EntityFrameworkCore;

namespace EFQuerySample.Hir;

public class EmpContext:DbContext
{
    public DbSet<Employe> Employes { get; set; }
    public DbSet<Type01> Type01s{ get; set; }
    public DbSet<Type02> Type02s{ get; set; }
    public DbSet<Type03> Type03s{ get; set; }
    public DbSet<Person> People { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=Empdb;User Id=sa; Password=1qaz!QAZ",options=> options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
    }
}
