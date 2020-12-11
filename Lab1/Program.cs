using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            MyLinkedList<int> List = new MyLinkedList<int>(new []{11,22,33});

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

            List.Remove(3);
            List.Remove(1);
            List.Remove(7);
            foreach (var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List.AppendHead(8);
            foreach (var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            List.AddAfter(4, 8);
            foreach (var item in List)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            if (List.Contains(4))
                Console.WriteLine("contains 4");

        }
    }
}
