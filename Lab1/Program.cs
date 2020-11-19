using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            MyLinkedList<int> List = new MyLinkedList<int>();

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

            List.Delete(3);
            List.Delete(1);
            List.Delete(7);
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

        }
    }
}
