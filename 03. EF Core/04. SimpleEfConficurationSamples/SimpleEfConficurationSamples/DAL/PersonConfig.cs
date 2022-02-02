using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConficurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.DAL;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(c=>c.FirstName).HasMaxLength(50);
        builder.Ignore(c=>c.Contacts);
    }
}

public class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(c => c.FirstName).HasMaxLength(100);
    }
}

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.customerType).HasConversion<string>();
        builder.Property(c=>c.Age).HasConversion(c=>c.ToString(),c=> int.Parse(c));
        builder.Property(c => c.TempIntWithStringValue).HasConversion<MyIntToStringConverter>();
        
    }
}
