namespace DependencyInjectionSample.DI;

public interface ITransientDependency
{
    string GetGuid();
}
public class TransientDependency : ITransientDependency
{
    private readonly Guid _guid;
    private readonly IScopeDependency _scopeDependency;

    public TransientDependency(IScopeDependency scopeDependency,ISingletoneDependency singletoneDependency)
    {
        _guid = Guid.NewGuid();
        _scopeDependency = scopeDependency;
    }

    public string GetGuid()
    {
        return $"{_guid}";
    }
}
