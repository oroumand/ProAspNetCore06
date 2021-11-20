using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTypes.Classes
{
    public class Singleton
    {
        private static Singleton instance;
        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
