using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class ForegroundBackgroundThreadSample
{
    public void Start()
    {
        Thread thread = new Thread(PrintAndRead);        
        thread.IsBackground = true;
        thread.Start();
        Console.WriteLine("Main thread Finished");
        thread.Join(TimeSpan.FromSeconds(10));
    }

    public void PrintAndRead()
    {
        Console.Write("Pleas enter a word: ");
        Console.ReadLine();

    }
}
