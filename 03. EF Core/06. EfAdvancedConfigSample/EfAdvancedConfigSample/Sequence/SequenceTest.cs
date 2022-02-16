using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAdvancedConfigSample.Sequence;
public class SequenceTestDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Initial Catalog=SequenceDb;User Id=sa; Password=1qaz!QAZ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence("Sample", "dbo", (c) =>
        {
            c.IncrementsBy(20);
            c.IsCyclic();
        });
    }

}
