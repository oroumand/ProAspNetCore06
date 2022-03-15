using EfAdvancedConfigSample.TemporalTables;

PersonTemporalContext Context = new PersonTemporalContext();
PersonTemporalRepository repository = new(Context);
repository.PrintAllWithHistory();
Console.ReadLine();