using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class LinkedListSample
    {
        LinkedList<string> list = new LinkedList<string>();

        public void Add(string input)
        {
            list.AddLast(input);

            LinkedListNode<string> node = new LinkedListNode<string>(input);

        }

        public void AddSeccondNode(string input)
        {
            LinkedListNode<string> node = new LinkedListNode<string>(input);

            var first = list.First;
            list.AddAfter(first,node);
        }
    }
}
