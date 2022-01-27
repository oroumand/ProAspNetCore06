using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyAndAsynchron.ThreadSample;
public class ThreadMethodSamples
{
    public void CreateThreadSample()
    {
        CharPrinter charPrinter = new CharPrinter();

        Thread dashPrinterWorker = new Thread(charPrinter.PrintDash);
        dashPrinterWorker.Name = "DashPrinterWorker";

        Console.WriteLine($"DashPrinterWorker is Alive befor start? {dashPrinterWorker.IsAlive}");

        dashPrinterWorker.Start();
        Console.WriteLine($"DashPrinterWorker is Alive after start? {dashPrinterWorker.IsAlive}");

        charPrinter.PrintStar();

        Console.WriteLine($"DashPrinterWorker is Alive after print Star? {dashPrinterWorker.IsAlive}");

        Console.ReadLine();

        Console.WriteLine($"DashPrinterWorker is Alive after read line? {dashPrinterWorker.IsAlive}");
        Console.ReadLine();
    }

    public void JoinSample()
    {
        CharPrinter charPrinter = new CharPrinter();
        Thread dashPrinterWorker = new Thread(charPrinter.PrintDash);
        dashPrinterWorker.Start();
        var result = dashPrinterWorker.Join(100);
        Console.WriteLine(result);
        charPrinter.PrintStar();
        Console.ReadLine();
    }

    public void SleepSaple()
    {
        CharPrinter charPrinter = new CharPrinter();
        Thread dashPrinterWorker = new Thread(charPrinter.PrintDash);
        dashPrinterWorker.Start();
        charPrinter.PrintStar();
        Console.ReadLine();
    }

    public void ThreadStateCheck()
    {
        CharPrinter charPrinter = new CharPrinter();
        Thread dashPrinterWorker = new Thread(charPrinter.PrintDash);
        dashPrinterWorker.Start();

        Console.WriteLine(dashPrinterWorker.ThreadState);
        var isBlock = (dashPrinterWorker.ThreadState & ThreadState.WaitSleepJoin) != 0;
        Console.WriteLine($"dash printer worker is block? {isBlock}");
    }
}
