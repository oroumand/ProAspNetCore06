using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.AccessModifiers
{
    public class MyDisposable : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class MyEnumerable : IEnumerable<MyDisposable>
    {
        public IEnumerator<MyDisposable> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class MyComparable : IComparable<MyComparable>
    {
        public int CompareTo(MyComparable? other)
        {
            
            throw new NotImplementedException();
        }
    }
}
