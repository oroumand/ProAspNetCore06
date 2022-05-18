namespace DependencyInjectionSample.Factory;

public interface IMyFactorySample
{
    string GetText();
}
public class MyFirstFactory : IMyFactorySample
{
    public string GetText()
    {
        return
                    nameof(MyFirstFactory);
    }
}
public class MySecondFactory : IMyFactorySample
{
    public string GetText()
    {
        return
    nameof(MySecondFactory);
    }
}