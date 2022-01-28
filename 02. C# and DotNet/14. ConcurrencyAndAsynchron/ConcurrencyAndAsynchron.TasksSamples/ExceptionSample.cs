using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.TasksSamples;
public class ExceptionSample
{
    public void Start()
    {
        Task<int> badMethod = Task.Run(() => BadMethod(null, 10));
        try
        {            
            badMethod.Wait();
            Console.WriteLine("BadMethod Finished");
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(badMethod.IsCanceled);
            Console.WriteLine(badMethod.IsFaulted);
            Console.WriteLine(ex.Message);
        }
       
    }

    public int BadMethod(int? num1,int? num2)
    {
        if(num1 == null)
        {
            throw new ArgumentNullException(nameof(num1));
        }
        if (num2 == null)
        {
            throw new ArgumentNullException(nameof(num2));
        }
        return num1.Value + num2.Value;
    }
}
