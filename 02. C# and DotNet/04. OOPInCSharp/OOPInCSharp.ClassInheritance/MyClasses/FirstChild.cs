using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.ClassInheritance.MyClasses
{
    public class FirstChild:Parent
    {
        public string GetChidlClassName()=>nameof(FirstChild);


        public new string HiddenMethod() => nameof(HiddenMethod);
    }
}
