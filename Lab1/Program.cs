using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            MyLinkedList List = new MyLinkedList();
            List.AddToEnd(3);
            List.AddToEnd(4);
            List.AddToEnd(5);
            List.AddToEnd(2);
            List.AddToBeginning(13);
            List.AddToBeginning(14);
            List.AddToBeginning(15);
            List.AddSorted(12);
            List.AddSorted(31);
            List.AddSorted(41);
            List.AddSorted(51);
            List.AddSorted(2);
            List.Print();
        }
    }
}
