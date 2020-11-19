using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class MyLinkedList<T> : IEnumerable
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public MyLinkedList()
        {
            Clear();
        }

        public MyLinkedList(T data)
        {
            var node = new Node<T>(data);
            SetHeadAndTail(node);
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if(Tail != null)
            {
                Tail.Next = node;
                Tail = node;
                Count++;
            }
            else
            {
                SetHeadAndTail(node);
            }
        }

        public void Delete(T data)
        {
            if (Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;
                while (current.Next != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
        }

        public void AppendHead(T data)
        {
            var node = new Node<T>(data)
            {
                Next = Head
            };

            Head = node;
            Count++;
        }

        public void AddAfter(T target, T data)
        {
            if (Head != null)
            {

                var current = Head;

                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var node = new Node<T>(data);
                        node.Next = current.Next;
                        current.Next = node;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                //SetHeadAndTail(new Node<T>(target));
                //Add(data);
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void SetHeadAndTail(Node<T> node)
        {
            Head = node;
            Tail = node;
            Count = 1;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return "Linked List " + Count + " elements";
        }
    }
}