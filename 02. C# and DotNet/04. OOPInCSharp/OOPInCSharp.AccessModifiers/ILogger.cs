using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPInCSharp.AccessModifiers
{
    public interface ILogger
    {
        void Log(string message);
        public void Info(string message)=>throw new NotImplementedException();
    }

    public class ConsulLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        public void Info(string message)
        {

        }
    }
}
