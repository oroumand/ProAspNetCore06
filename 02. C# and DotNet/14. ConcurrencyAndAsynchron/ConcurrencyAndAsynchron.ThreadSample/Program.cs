using ConcurrencyAndAsynchron.ThreadSample;

Task.Run(() => PrintThreadType());
Console.Read();


void PrintThreadType()
{
    var isPool = Thread.CurrentThread.IsThreadPoolThread;
    var isBackground = Thread.CurrentThread.IsBackground;
    Console.WriteLine($"Is Thread from pool? {isPool}");
    Console.WriteLine($"Is background Thread ? {isBackground}");
}
