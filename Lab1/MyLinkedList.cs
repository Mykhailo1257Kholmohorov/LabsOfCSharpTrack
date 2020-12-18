using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab1
{
    public class MyLinkedList<T> :ICollection<T>, ICollection
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        // Колекция не только для чтения
        public bool IsReadOnly
        {
            get { return false; }
        }

        // количество элементов
        public int Count { get; private set; }

        // проверка пустой ли список
        public bool IsEmpty { get { return Count == 0; } }

        // индексатор
        public T this[int index]
        {
            get
            {
                Node<T> temp = Head;
                for (int i = 0; i < index; i++)
                    temp = temp.Next;
                return temp.Data;
            }
            set
            {
                Node<T> temp = Head;
                if(index > Count-1)
                    throw new IndexOutOfRangeException("Your index out of range");
                for (int i = 0; i < index; i++)
                    temp = temp.Next;
                temp.Data = value;
            }
        }

        public MyLinkedList()
        {
        }

        public MyLinkedList(T data)
        {
            var node = new Node<T>(data);
            SetHeadAndTail(node);
        }
        // инициализируем массивом
        public MyLinkedList(T[]array)
        {
            var node = new Node<T>(array[0]);
            SetHeadAndTail(node);
            for (int i = 1; i < array.Length; i++)
            {
                this.Add(array[i]);
            }

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
        public bool Remove(T data)
        {
            if (Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return true;
                }
                var current = Head.Next;
                var previous = Head;
                while (current.Next != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return true;
                    }
                    previous = current;
                    current = current.Next;
                }
            }

            return false;
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
        public void CopyTo(T[] array, int arrayIndex)
        {
            if(array == null)
                throw new ArgumentNullException("Array is null");
            if(arrayIndex < 0)
                throw new ArgumentOutOfRangeException("array Index less then 0");
            if(Count - arrayIndex- 1 > array.Length)
                throw new ArgumentException("The number of elements in the source collection is greater than the available space");
            
            for (int i = 0; i < array.Length; i++, arrayIndex++)
            {
                array[i] = this[arrayIndex];
            }
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

        public void CopyTo(Array array, int index)
        {
            this.CopyTo(array,index);
        }
        public bool IsSynchronized { get { return true; } }

        public object SyncRoot { get; }
    }
}