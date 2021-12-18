using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class PriorityQueueSample
    {
         PriorityQueue<string,int> PriorityQueue = new PriorityQueue<string,int>();
        public void Start()
        {
            PriorityQueueSample ps = new PriorityQueueSample();
            ps.AddWithDiffrentPriority();
        }
        public void AddWithSamePriority()
        {
            PriorityQueue.Enqueue("1", 1);
            PriorityQueue.Enqueue("2", 1);
            PriorityQueue.Enqueue("3", 1);


            Console.WriteLine(PriorityQueue.Dequeue());
            Console.WriteLine(PriorityQueue.Dequeue());
            Console.WriteLine(PriorityQueue.Dequeue());
        }


        public void AddWithDiffrentPriority()
        {
            PriorityQueue.Enqueue("1", 5);
            PriorityQueue.Enqueue("2", 8);
            PriorityQueue.Enqueue("3", 1);
            

            Console.WriteLine(PriorityQueue.Dequeue());
            Console.WriteLine(PriorityQueue.Dequeue());
            Console.WriteLine(PriorityQueue.Dequeue());
        }

    }
}
