using EfMigrationSamples;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


PersonContext _personContext = new PersonContext();
_personContext.Database.Migrate();