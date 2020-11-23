using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class MyLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        // количество элемнтов
        public int Count { get; private set; }
        // проверка пустой ли список
        public bool IsEmpty { get { return Count == 0; } }

        public MyLinkedList()
        {
            Clear();
        }

        public MyLinkedList(T data)
        {
            var node = new Node<T>(data);
            SetHeadAndTail(node);
        }

        // добавить элемент в конец списка
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

        //удалить элемент в списке
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

        // добавить элемент в начало списка
        public void AppendHead(T data)
        {
            var node = new Node<T>(data)
            {
                Next = Head
            };

            Head = node;
            Count++;
        }

        // добавить элемент после искомого элемента
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

        // очистить список
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        //проверяем содержит ли список элемент
        public bool Contains(T data)
        {
            var current = Head;
            while(current != null)
            {
                if(current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        private void SetHeadAndTail(Node<T> node)
        {
            Head = node;
            Tail = node;
            Count = 1;
        }

        //перечисление всех элементов списка
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
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