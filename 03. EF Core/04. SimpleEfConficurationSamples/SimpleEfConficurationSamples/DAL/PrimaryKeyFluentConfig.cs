using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConficurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.DAL;
public class PrimaryKeyFluentConfig : IEntityTypeConfiguration<PrimaryKeyFluent>
{
    public void Configure(EntityTypeBuilder<PrimaryKeyFluent> builder)
    {
        builder.HasKey(c => new { c.Pk01, c.Pk02 });
    }
}
