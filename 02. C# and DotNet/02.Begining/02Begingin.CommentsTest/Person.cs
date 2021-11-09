using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Begingin.CommentsTest
{
    /// <summary>
    /// This is a person Class
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// First Name Of Person
        /// </summary>
        public int FirstName { get; set; }
        public int LastName { get; set; }

        /// <summary>
        /// Calculate Full Name
        /// </summary>
        /// <returns>Full Name String </returns>
        public string GetFullName()
        {
            //Commant
            int a = 11;//10;

            /*
             * asdf
             * adsfsadf
             * asdfsadfas
             * asdfadsf
             * 
           */
            return $"{FirstName} {LastName}";
        }
    }
}
