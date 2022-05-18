namespace DependencyInjectionSample.DI;

public interface ISingletoneDependency
{
    string GetGuid();
}
public class SingletoneDependency: ISingletoneDependency
{
    private readonly Guid _guid;
    private readonly ISingletoneDependency2 _dependency2;
    private readonly ITransientDependency _transientDependency;

    public SingletoneDependency()
        //ISingletoneDependency2 dependency2
        //,ITransientDependency transientDependency)
    {
        _guid = Guid.NewGuid();
        //_dependency2 = dependency2;
        //_transientDependency = transientDependency;

    }

    public string GetGuid()
    {
        return $"{_guid} --- {_dependency2.GetGuid()}";
    }
}

public interface ISingletoneDependency2
{
    string GetGuid();
}


public class SingletoneDependency2 : ISingletoneDependency2
{
    private readonly Guid _guid;
    public SingletoneDependency2()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _guid.ToString();
    }
}

public class ConcreatSingleton
{
    private readonly Guid _guid;
    public ConcreatSingleton()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return _guid.ToString();
    }
}