namespace DependencyInjectionSample.DI;

public interface IScopeDependency
{
    string GetGuid();
}
public class ScopeDependency : IScopeDependency
{
    private readonly Guid _guid;
    //private readonly ITransientDependency _transientDependency;
    //private readonly ISingletoneDependency _singletoneDependency;

    //public ScopeDependency(ITransientDependency transientDependency,ISingletoneDependency singletoneDependency)
    public ScopeDependency()
    {
        _guid = Guid.NewGuid();

    }

    public string GetGuid()
    {
        return $"{_guid}";
    }
}
