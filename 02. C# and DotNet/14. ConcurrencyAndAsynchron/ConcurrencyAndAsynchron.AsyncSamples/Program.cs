using ConcurrencyAndAsynchron.AsyncSamples;
var sample02 = new Sample02();

var after3 = sample02.PrintAfter3();
var after4 = sample02.PrintAfter4();
var after5 = sample02.PrintAfter5();
//await Task.WhenAll(after3, after4, after5);
await Task.WhenAny(after3, after4, after5);
//Console.ReadLine();

