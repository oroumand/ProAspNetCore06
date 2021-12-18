using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionFirstLook
{
    public class QueueSample
    {
        Queue<string> queue = new Queue<string>();
        public void Start()
        {
            Console.WriteLine("Hello, World!");
            QueueSample queueSample = new QueueSample();
            queueSample.CountAndCapacity();
            queueSample.Enqueue("01");
            queueSample.Enqueue("02");
            queueSample.Enqueue("03");
            queueSample.CountAndCapacity();
            Console.ReadLine();
            Console.WriteLine(queueSample.Peek());
            queueSample.CountAndCapacity();
            Console.WriteLine(queueSample.Peek());
            queueSample.CountAndCapacity();
            Console.WriteLine(queueSample.Peek());
            queueSample.CountAndCapacity();

            Console.ReadLine();
            Console.WriteLine(queueSample.Dequeue());
            queueSample.CountAndCapacity();
            Console.WriteLine(queueSample.Dequeue());
            queueSample.CountAndCapacity();
            Console.WriteLine(queueSample.Dequeue());
            queueSample.CountAndCapacity();
            Console.ReadLine();
        }
        public void Enqueue(string input)
        {
            queue.Enqueue(input);
        }
        public string Dequeue()
        {
            return queue.Dequeue();
        }

        public string Peek()
        {
            return queue.Peek();
        }
        public void CountAndCapacity()
        {        
            Console.WriteLine($"Count is :{queue.Count}");
        }
    }
}
