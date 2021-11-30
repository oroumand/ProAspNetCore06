using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySample
{
    internal class ArrayFunctions
    {
        public void Simple()
        {
            int a = 1;

            int[] b = new int[10];

            int[] c = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            int[] d = { 1, 2, 3, 4, 5, 6, 7, 8 };

            Console.WriteLine(b[0]);

            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
        }
        public void TowDimension()
        {
            int[] a = new int[10];
            int[,,] c = new int[10, 10, 10];
            int[,] vs = new int[2, 2];
            vs[0, 0] = 1;
            vs[1, 0] = 2;
            vs[0, 1] = 3;
            vs[1, 1] = 4;

            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"A dimension is {a.Rank}");
            Console.WriteLine($"vs dimension is {vs.Rank}");
            Console.WriteLine($"c dimension is {c.Rank}");
        }

        public void JaggedArray()
        {
            int[][] jagged = new int[3][];
            jagged[0] = new int[] { 1, 3, 6 };
            jagged[1] = new int[] { 2, 4, 6, 8, 10 };
            jagged[2] = new int[] { 3, 7 };

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.WriteLine($"Value of {i} and {j} is: {jagged[i][j]}");
                }
            }
        }


        public void ArrayClassSample()
        {
            var myArray = Array.CreateInstance(typeof(int), 10);
            for (int i = 0;i<myArray.Length ; i++)
            {
                myArray.SetValue(i,i);
            }

            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray.GetValue(i));
            }
        }

        public void CopyArray()
        {
            var myArray = Array.CreateInstance(typeof(int), 10);
            var seccondArray = myArray.Clone();
            int[] third = new int[5];
            Array.Copy(myArray, third, 5);
        }

        public void SortArray()
        {
            int[] d = { 10, 5, 3, 7, 2, 6,9, 8 };
            Array.Sort(d);
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
        }

        public void TestEnumeration()
        {
            int[] a = new int[] { 1, 2, 3, 4 };

            //foreach (var item in a)
            //{

            //}

            var e = a.GetEnumerator();
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }

        public void TestHat()
        {
            int[] c = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine(c[0]);
            Console.WriteLine(c[1]);
            Console.WriteLine(c[^1]);
            Console.WriteLine(c[^2]);
        }

        public void TestRange()
        {
            int[] c = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var e = c[0..4];
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }
        }

        public void TestHatAndRange()
        {
            int[] c = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var e = c[^4..^1];
            foreach (var item in e)
            {
                Console.WriteLine(item);
            }
        }

        public void ArrayPool()
        {
            ArrayPool<int> arrayPool = ArrayPool<int>.Create();

            var array = arrayPool.Rent(17);

            for (int i = 0; i < 17; i++)
            {
                array[i] = i * 2;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            arrayPool.Return(array,true);
        }

        public void TestBitArray()
        {
            BitArray bit01 = new(4);
            bit01.SetAll(true);
            bit01[2] = false;

            BitArray bit02 = new(4);
            bit02.SetAll(true);
            
            bit01.Xor(bit02);

            foreach (var item in bit01)
            {
                Console.WriteLine(item);
            }
        }
    }


    public class Person : IComparable<Person>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public int CompareTo(Person? other)
        {
            if(this.Id == other.Id)
            {
                return 0;
            }
            else if(this.Id > other.Id)
            {
                return 1;
            }
            else
                return -1;
        }

       
    }

    public class PersonComparerFirstName : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            throw new NotImplementedException();
        }
    }


}
