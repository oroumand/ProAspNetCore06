using ConcurrencyAndAsynchron.TasksSamples;

//ContinuationsSample continuations = new();
//continuations.Start2();

Task.Delay(2000).ContinueWith(task => Console.WriteLine("Text after 2 Secconds"));
Console.ReadLine();
