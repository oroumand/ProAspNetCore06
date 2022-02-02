using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEfConficurationSamples.Models;

namespace SimpleEfConficurationSamples.DAL;
public class BackingFiledSampleConfig : IEntityTypeConfiguration<BackingFiledSample>
{
    public void Configure(EntityTypeBuilder<BackingFiledSample> builder)
    {
        builder.Property(c => c.FatherName).HasField("_fatherNameField");

        builder.Property<DateTime>("_dateOfBirth").HasColumnName("DateOfBirth");

    }
}
