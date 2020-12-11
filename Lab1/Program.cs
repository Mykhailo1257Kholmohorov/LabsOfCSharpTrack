using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            MyLinkedList<int> List = new MyLinkedList<int>(new []{11,22,33});

            Console.WriteLine(List.Count);
            Console.WriteLine("=======================");

            Console.WriteLine(List.IsEmpty);
            Console.WriteLine("=======================");

            List.Add(1);
            List.Add(2);
            List.Add(3);
            List.Add(4);
            List.Add(5);

            foreach(var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=======================");

            List.Remove(3);
            List.Remove(1);
            List.Remove(7);
            foreach (var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=======================");

            List.AppendHead(8);
            foreach (var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=======================");

            List.AddAfter(4, 8);
            foreach (var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=======================");

            if (List.Contains(4))
                Console.WriteLine("contains 4");
            Console.WriteLine("=======================");

            int[] array = new int[3];

            List.CopyTo(array,5);
            foreach (var el in array)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine("=======================");

            List.Clear();
            Console.WriteLine(List.IsEmpty);

        }
    }
}
