using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DisposeAndGcSamples.MemoryLeaks;
public class Host
{
    public event EventHandler<EventArgs> HostChanged;
}

public class Client:IDisposable
{
    private readonly Host _host;

    public Client(Host host)
	{
        _host = host;
        _host.HostChanged += _host_HostChanged;
    }

    public void Dispose()
    {
        _host.HostChanged -= _host_HostChanged;
    }

    private void _host_HostChanged(object? sender, EventArgs e)
    {
        //Do Sth
    }
}


public class MyUserClass
{

    static Host host = new Host();
    public static void UseClient()
    {
        Client[] clients = Enumerable.Range(0,10000).Select(c=>new Client(host)).ToArray();
        //do  somethin
    }
}