namespace HostedServiceSamples.PostsSample.Infrastructures;

public interface IFakeService
{
    bool GetTrue();
}
public class FakeService : IFakeService
{
    public bool GetTrue()
    {
        return true;
    }
}
