using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.AsyncSamples;
public class PrimeNumberSample
{

    private int GetPrimeNumberCount(int startFrom, int count)
    {
        return Enumerable.Range(startFrom, count).Count(c =>
            Enumerable.Range(2, (int)(Math.Sqrt(c) - 1)).All(d => c % d != 0));
    }

    private Task<int> GetPrimeNumberCountAsync(int startFrom, int count)
    {
        return Task.Run(()=> Enumerable.Range(startFrom, count).Count(c =>
            Enumerable.Range(2, (int)(Math.Sqrt(c) - 1)).All(d => c % d != 0)));
    }

    public void DisplayPrimeNumeV1()
    {
        int count = 1_000_000;
        for (int i = 0; i < 10; i++)
        {
            int start = i * count + 2;
            int itemCount = count - 3;

            Console.WriteLine($"Thre are {GetPrimeNumberCount(start,count)} between {start} and {start + itemCount}" );
        }
        Console.WriteLine("Done");
    }


    public void DisplayPrimeNumeV2()
    {
        int count = 1_000_000;
        for (int i = 0; i < 10; i++)
        {
            int start = i * count + 2;
            int itemCount = count - 3;

            Console.WriteLine($"Thre are {GetPrimeNumberCountAsync(start, count)} between {start} and {start + itemCount}");
        }
        Console.WriteLine("Done");
    }

    public void DisplayPrimeNumeV3()
    {
        int count = 1_000_000;
        for (int i = 0; i < 10; i++)
        {
            int start = i * count + 2;
            int itemCount = count - 3;
            var awaiter = GetPrimeNumberCountAsync(start, count).GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Console.WriteLine($"Thre are {awaiter.GetResult()} between {start} and {start + itemCount}");
            });
            
        }
        Console.WriteLine("Done");
    }

    public void DisplayPrimeNumV4()
    {
        DisplayPrimeNumInner(0, 1_000_000);
    }

    private void DisplayPrimeNumInner(int i,int count)
    {
        int start = i * count + 2;
        int itemCount = count - 3;
        var awaiter = GetPrimeNumberCountAsync(start, count).GetAwaiter();

        awaiter.OnCompleted(() =>
        {
            Console.WriteLine($"Thre are {awaiter.GetResult()} between {start} and {start + itemCount}");
            i++;
            if(i <10)
            {
                DisplayPrimeNumInner(i, count);
            }
            else
            {
                Console.WriteLine("Done");
            }
        
        });
    }

    public async Task DisplayPrimeNumeV5()
    {
        int count = 1_000_000;
        for (int i = 0; i < 10; i++)
        {
            int start = i * count + 2;
            int itemCount = count - 3;

            Console.WriteLine($"Thre are {await GetPrimeNumberCountAsync(start, count)} between {start} and {start + itemCount}");
        }
        Console.WriteLine("Done");
    }


}
