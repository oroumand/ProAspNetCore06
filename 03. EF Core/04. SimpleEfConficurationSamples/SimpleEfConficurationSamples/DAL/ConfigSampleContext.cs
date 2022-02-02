using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleEfConficurationSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEfConficurationSamples.DAL;
public class ConfigSampleContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<TypeAndNameWithAttribute> typeAndNameWithAttributes { get; set; }
    public DbSet<PrimaryKeyAttribute> PrimaryKeyAttributes { get; set; }
    public DbSet<PrimaryKeyFluent> primaryKeyFluents { get; set; }
    public DbSet<ReadonlyAttribute> ReadonlyAttributes { get; set; }
    public DbSet<ReadonlyFluent> ReadonlyFluents { get; set; }
    public DbSet<IndexUsingAttribute> IndexUsingAttributes { get; set; }
    public DbSet<IndexUsingFluent> IndexUsingFluents { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<News> News { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.; Initial Catalog=ConfigSampleDb;User Id=sa; Password=1qaz!QAZ");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if(Database.IsSqlServer())
        {
            //Config For Sql Server
        }

        if(Database.IsRelational())
        {

        }
        //modelBuilder.ApplyConfiguration(new PersonConfig());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfig).Assembly);
        //modelBuilder.Entity<Person>().Ignore(c => c.Contacts);
        modelBuilder.Ignore<Contact>();
        modelBuilder.Entity<ReadonlyFluent>().HasNoKey();

        modelBuilder.Entity<IndexUsingFluent>().HasIndex(c => c.Name).IsUnique();//.HasFilter("IS Not Filtered");
        modelBuilder.HasDefaultSchema("ef1");

        modelBuilder.Entity<Train>().ToTable("tbl_train", "ef2");
        modelBuilder.Entity<Train>().Property(c=>c.TrainName).HasColumnName("fld_TrainName");

        var utcConverter = new ValueConverter<DateTime, DateTime>(
            toDb => toDb,
            fromDb =>
            DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));


        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var entityProperty in entityType.GetProperties())
            {
                if (entityProperty.ClrType == typeof(DateTime)
                && entityProperty.Name.EndsWith("Utc"))
                {
                    entityProperty.SetValueConverter(utcConverter);
                }
            }
        }



    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(200).AreUnicode(false);
    }
}
