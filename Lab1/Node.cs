using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int i)
        {
            Data = i;
            Next = null;
        }

        public void Print()
        {
            Console.Write("|" + Data + "|->");
            if(Next != null)
            {
                Next.Print();
            }
        }

        public void AddSorted(int data)
        {
            if (Next == null)
            {
                Next = new Node(data);
            }
            else if (data < Next.Data)
            {
                Node temp = new Node(data);
                temp.Next = this.Next;
                this.Next = temp;
            }
            else
            {
                Next.AddSorted(data);
            }
        }
        public void AddToEnd(int data)
        {
            if(Next == null)
            {
                Next = new Node(data);
            }
            else
            {
                Next.AddToEnd(data);
            }
        }
    }
}
