using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Begining.Variables
{
    public class VariableScope
    {
        private int _age;


        public int GetAge()
        {

            int birthDay = 11;
            if (birthDay < 11)
            {
                int birthYear = 1999;
            }

         


            return _age;
        }

        public void SetAge(int age)
        {
            _age = age;
        }
    }
}
