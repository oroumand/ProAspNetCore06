using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class PassDataSample
{
    public void Start()
    {
        Thread worker = new Thread(()=> PrintFullName("Alireza","Oroumand"));
        worker.Start();
        Console.Read();

    }

    public void CaptureVariableProblem()
    {
        string fullName = "Hassan Mohammadi";
        Thread firstThread = new Thread(() => Console.WriteLine(fullName));
        fullName = "Alireza Oroumand";
        Thread seccondThread = new Thread(() => Console.WriteLine(fullName));
        firstThread.Start();
        seccondThread.Start();
        Console.Read();
    }

    public void PrintNumber()
    {
        for (int i = 0; i < 10; i++)
        {
            int temp = i;
            new Thread(()=>Console.WriteLine(temp)).Start();
        }
    }
    public void ObjectSampleInStart()
    {
        Thread worker = new Thread(PrintObject);
        string hello = "Hello world";
        worker.Start(hello);
        Console.Read();
    }
    public void PrintObject(object input)
    {
        Console.WriteLine(input.ToString());
    }
    public void PrintFullName(string firstName,string lastName)
    {
        Console.WriteLine($"{firstName}, {lastName}");
    }
}
