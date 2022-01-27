using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class ExceptionInThreads
{
    public void Start()
    {

        Thread worker = new Thread(ThreadStartPoint);
        worker.Start();
        Console.Read();


    }

    public void ThreadStartPoint()
    {
        try
        {
            BadMethod();
        }
        catch (Exception)
        {
            Console.WriteLine("Exception!!!!");
        }
    }
    public void BadMethod()
    {
        throw new Exception("Bad method exception");
    }
}
