using AttributeSample.Domain;
using AttributeSamples.DiscoveringMetadata;

var intPrinter = new MetaDataPrinter(typeof(int));
var peronPrinter = new MetaDataPrinter(typeof(Person));

//intPrinter.Print();
//Console.WriteLine("Press any key to print Person metadata");
//Console.ReadKey();
//Console.Clear();
peronPrinter.Print();
Console.WriteLine("Press any key to Exit");
Console.ReadKey();