// See https://aka.ms/new-console-template for more information
using ExceptionHandling;

Console.WriteLine("Hello, World!");


Calculator calculator = new Calculator();
try
{
    calculator.Add(1, 2);
    calculator.Add(0, 3);

}
catch(InvalidOperationException ex) when (DateTime.Now.Hour == 2)
{

}
catch (InvalidOperationException ex) when (DateTime.Now.Hour == 3)
{

}
catch (Exception ex) when (ex.InnerException != null)
{
    Console.WriteLine(ex.Message);
    MyCustomException myCustomException = new MyCustomException("My Exception",ex);
    
    throw myCustomException;

}
finally
{
    Console.WriteLine("Finally");
}
