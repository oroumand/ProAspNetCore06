using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Begining
{
    namespace NamespaceTest
    {
        namespace Inner01
        {
            namespace Inner02
            {
                internal class Person
                {
                    public FsNamespace FsNamespace { get; set; }
                }
            }
        }

    }

}

namespace Begining.NamespaceTest.Inner01.Inner02
{
    public class Teacher
    {

    }
}
