using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConficurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.DAL;
public class TypeAndNameWithFluentConfig : IEntityTypeConfiguration<TypeAndNameWithFluent>
{
    public void Configure(EntityTypeBuilder<TypeAndNameWithFluent> builder)
    {
        builder.Property(c=>c.Name).IsUnicode(false).HasMaxLength(50);
        builder.Property(c => c.Price).HasPrecision(14, 4);
        builder.Property(c=>c.Code).HasMaxLength(10).IsUnicode(false);
    }
}
