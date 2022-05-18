namespace DependencyInjectionSample.Dip;

public class MyApplicationService
{
    public void Handle()
    {
        //
        //
        //
        IRepository repo = RepoFactory.GetRepository();
        repo.Get("");
    }
}

public class RepoFactory
{
    public static IRepository GetRepository()=>
        new Repository();
}
public interface IRepository
{
    void Save();
    string Get(string input);
}
public class Repository: IRepository
{
    public void Save()
    {

    }
    public string Get(string input)
    {
        DateTime now = DateTime.Now;
        return now.ToString();
    }
    public int Test() => 1;
}
