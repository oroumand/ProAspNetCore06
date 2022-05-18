namespace DependencyInjectionSample.Ioc;

public class ClassA
{
    public void PrintName()
    {
        Printer printer = PrinterFactory.Create();
        printer.Print(nameof(ClassA));
    }
}
public class PrinterFactory
{
    public static Printer Create()=>
        new Printer();
}
public class Printer
{
    public void Print(string text)=>
        Console.WriteLine(text);
}
