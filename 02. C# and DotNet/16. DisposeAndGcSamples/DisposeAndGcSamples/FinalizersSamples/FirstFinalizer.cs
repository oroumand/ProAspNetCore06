using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeAndGcSamples.FinalizersSamples;
public class FirstFinalizer
{
    public FirstFinalizer()
    {

    }

    ~FirstFinalizer()
    {

    }
}


public class DisposeFinlilize : IDisposable
{
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            //Do Sth
        }

        //
    }
    DisposeFinlilize()
    {
        Dispose(false);
    }

}

public class ResurrectionSample
{
    public static List<ResurrectionSample> resurrectionSamples= new List<ResurrectionSample>();


    ~ResurrectionSample()
    {
        try
        {
            //Delete File
        }
        catch (Exception)
        {
            resurrectionSamples.Add(this);

        }

    }
}

public class ReRegister
{
    int TryCount = 0;
    ~ReRegister()
    {
        try
        {
            //Delete File
        }
        catch (Exception)
        {
            TryCount++;
            if(TryCount < 1) {
                GC.ReRegisterForFinalize(this);
            }
            else
            {
                //Log
            }
        }
    }
}