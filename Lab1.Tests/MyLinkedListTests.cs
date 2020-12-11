using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1.Tests
{
    [TestClass]
    public class MyLinkedListTests
    {
        [ExpectedException(typeof(IndexOutOfRangeException), "Exception was not thrown")]
        [TestMethod]
        public void LinkedListIndex_AssigningValueOutOfRange_Exception()
        {
            MyLinkedList<int> list = new MyLinkedList<int>(){1,2,3};

            list[3] = 5;
        }

        [TestMethod]
        public void Count_Create4ElementsInList_Returned4Elements()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>(new[] {3, 4, 5, 5});

            int count = myList.Count;

            Assert.AreEqual( 4, count, "In list should be 4 elements");
        }

        [TestMethod]
        public void IsEmpty_CreateEmptyList_ReturnedTrue()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>();

            var isEmpty = myList.IsEmpty;

            Assert.IsTrue(isEmpty, "List is not Empty");
        }

        [TestMethod]
        public void Add_Add5ToListEnd_LastElementEqual5()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>(new[] { 1, 3 });

            myList.Add(5);

            Assert.AreEqual( 5, myList.Head.Next.Next.Data, "List should have last element {0}", 5);
            CollectionAssert.Contains(myList, 5,"List should contain element {0}", 5);
        }

        [TestMethod]
        public void Remove_RemoveElementFromList_True()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>(){1,2,3,4,5};
            
            bool arg = myList.Remove(4);
            
            Assert.IsTrue(arg);
            Assert.AreEqual(4, myList.Count, "Number of element didn't change");
        }

        [TestMethod]
        public void AppendHead_Add5ToBeginOfTheList_HeadEqual5()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>() { 1, 2, 3, 4, 5 };
            int head = myList.Head.Data;

            myList.AppendHead(5);

            Assert.AreEqual(5,myList.Head.Data, "Head is not equal 5");
            //Assert.AreNotEqual(head, myList.Head.Data, "Head has not changed");
        }

        [TestMethod]
        public void AddAfter_Add3After5_NextAfter3Equal5()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>() { 1, 2, 3, 4, 5 };

            myList.AddAfter(3,5);

            CollectionAssert.Contains(myList,5, "List should contain element {0}", 5);
            Assert.AreEqual(5,myList[3],"Element after 3 is not 5");
        }

        [TestMethod]
        public void Clear_ClearList_True()
        {
            MyLinkedList<int> myList = new MyLinkedList<int>() { 1, 2, 3, 4, 5 };

            myList.Clear();

            Assert.AreEqual(null, myList.Head, "List is not clear");
        }

        [TestMethod]
        public void Contains_check5ContainsInList_True()
        {
            MyLinkedList<int> mList = new MyLinkedList<int>(){2,3,5,1,6,7};

            bool arg = mList.Contains(5);

            Assert.IsTrue(arg, "List doesn't contain 5");
        }

        [TestMethod]
        public void CopyTo_CopyLast3ElementsFromListToArray_ReturnedArrayWith3LastElementsFromList()
        {
            MyLinkedList<int> mList = new MyLinkedList<int>() { 2, 3, 5, 1, 6, 7 };
            int[] array = new int[3];

            mList.CopyTo(array,3);

            CollectionAssert.Contains(mList,array, "Elements hasn't copied to array");
        }
    }
}
