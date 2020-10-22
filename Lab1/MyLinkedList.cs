using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class MyLinkedList
    {
        public Node Head;

        public MyLinkedList()
        {
            Head = null;
        }

        public void AddToEnd(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else
            {
                Head.AddToEnd(data);
            }
        }
        public void AddSorted(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else if(data < Head.Data)
            {
                AddToBeginning(data);
            }
            else 
            {
                Head.AddSorted(data);            
            }
        }
        public void AddToBeginning(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.Next = Head;
                Head = temp;
            }
        }
        public void Print()
        {
            if(Head != null)
            {
                Head.Print();
            }
        }
    }
}
