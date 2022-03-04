using DbContextSamples;
MyDbContext context = new();
SampleSources sample = new(context);
sample.ChangeConnectionString();
Console.WriteLine("Press any key to exit ...");
Console.ReadLine();