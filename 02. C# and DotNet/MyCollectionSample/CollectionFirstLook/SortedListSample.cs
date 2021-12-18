using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class SortedListSample
    {
        SortedList<int,string> list = new SortedList<int,string>();

        public void Add(int key,string value)
        {

            list.Add(key, value);

        }


    }
}
