/* See License.md in the solution root for license information.
 * File: AddRemoveCallback.cs
*/
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class AddRemoveCallback
    {
        [TestMethod]
        public void TestAdd()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,SortOrder.Ascending,10);
            Assert.IsNotNull(o1);
            o1.Add(1,"A");
            o1.Add(2,"A");
            var e = o1.Remove();
            Assert.IsNotNull(e);
            Assert.AreEqual(1,o1.Count);
            Assert.AreEqual(1,e.Key);
            var p = o1.Peek;
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key,2);
            p = o1.Remove();
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key,2);
            Assert.IsTrue(o1.IsEmpty);
        }

        [TestMethod]
        public void TestReverseAdd()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,SortOrder.Ascending,10);
            Assert.IsNotNull(o1);
            o1.Add(2, "A");
            o1.Add(1, "A");
            var e = o1.Remove();
            Assert.IsNotNull(e);
            Assert.AreEqual(1, o1.Count);
            Assert.AreEqual(1, e.Key);
            var p = o1.Peek;
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key, 2);
            p = o1.Remove();
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key, 2);
            Assert.IsTrue(o1.IsEmpty);
        }

        [TestMethod]
        public void TestAddDescending()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,SortOrder.Descending,10);
            Assert.IsNotNull(o1);
            o1.Add(1, "A");
            o1.Add(2, "A");
            var e = o1.Remove();
            Assert.IsNotNull(e);
            Assert.AreEqual(1, o1.Count);
            Assert.AreEqual(2, e.Key);
            var p = o1.Peek;
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key, 1);
            p = o1.Remove();
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key, 1);
            Assert.IsTrue(o1.IsEmpty);
        }

        [TestMethod]
        public void TestAddReverseDescending()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,SortOrder.Descending,10);
            Assert.IsNotNull(o1);
            o1.Add(2, "A");
            o1.Add(1, "A");
            var e = o1.Remove();
            Assert.IsNotNull(e);
            Assert.AreEqual(1, o1.Count);
            Assert.AreEqual(2, e.Key);
            var p = o1.Peek;
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key, 1);
            p = o1.Remove();
            Assert.IsNotNull(p);
            Assert.AreEqual(p.Key, 1);
            Assert.IsTrue(o1.IsEmpty);
        }

        [TestMethod]
        public void TestRemoveFromTheMiddle()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o1);
            o1.Add(3,"C");
            o1.Add(2,"B");
            o1.Add(1,"A");
            var r = o1.Remove(2);
            Assert.IsNotNull(r);
            Assert.AreEqual(r.Value.Index,2);
            Assert.AreEqual(o1.Count,2);
            var top = o1.Peek;
            Assert.IsNotNull(top);
            Assert.AreEqual(top.Value.Index,1);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestRemoveFromEmpty()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            var pick = o1.Remove();
        }

        [TestMethod]
        public void TestRemoveFromInside()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,SortOrder.Descending);
            Assert.IsNotNull(o1);
            const string letters = "ABCDEFGHIJ";
            for (int i = 0; i < letters.Length; i++)
            {
                o1.Add(i+1,letters.Substring(i,1));
            }
            var pick = o1.Remove(2);
            Assert.IsNotNull(pick);
            Assert.AreEqual(pick.Value.Index,2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestRemoveFromInsideWithNonExistentKey()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o1);
            const string letters = "ABCDEFGHIJ";
            for (int i = 0; i < letters.Length; i++)
            {
                o1.Add(i + 1, letters.Substring(i, 1));
            }
            var pick = o1.Remove(-1);
        }

        [TestMethod]
        public void RemoveFromLongerQ()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,SortOrder.Descending);
            Assert.IsNotNull(o1);
            const string letters = "ABCDEFGHIJ";
            for (int i = 0; i < letters.Length; i++)
            {
                o1.Add(i + 1, letters.Substring(i, 1));
            }
            var pick = o1.Remove();
            Assert.IsNotNull(pick);
            Assert.AreEqual(pick.Key, letters.Length);
        }

        [TestMethod]
        public void TestClear()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o1);
            o1.Add(1,"A");
            o1.Add(2,"B");
            o1.Clear();
            Assert.AreEqual(o1.Count,0);
        }

        [TestMethod]
        public void TestUseAfterClear()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o1);
            o1.Add(1, "A");
            o1.Add(2, "B");
            o1.Clear();
            Assert.AreEqual(o1.Count, 0);
            o1.Add(2, "B");
            o1.Add(1, "A");
            var top = o1.Peek;
            Assert.AreEqual(top.Key,1);
        }

        [TestMethod]
        public void TestGet()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback, SortOrder.Descending);
            Assert.IsNotNull(o1);
            o1.Add(1, "A");
            o1.Add(2, "B");
            var top = o1.Get(2);
            Assert.AreEqual(top.Key, 1);
        }

        [TestMethod]
        public void TestIndexer()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback, SortOrder.Descending);
            Assert.IsNotNull(o1);
            var I = (IPriorityQueueWithIndexing<int, TestValueClass>) o1;
            Assert.IsNotNull(I);
            o1.Add(1, "A");
            o1.Add(2, "B");
            var top = I[2];
            Assert.AreEqual(top.Key, 1);
        }

        [TestMethod]
        public void TestSimpleEnqueueDequeue()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o);
            var I = (IPriorityQueueWithIndexing<int, TestValueClass>)o;
            Assert.IsNotNull(I);
            I.Enqueue(2, "B");
            I.Enqueue(1, "A");
            var top = I.Dequeue(2);
            Assert.AreEqual(top.Key, 2);
            Assert.AreEqual(o.Count, 1);
            top = I.Dequeue();
            Assert.AreEqual(top.Key, 1);
            Assert.AreEqual(o.Count, 0);
        }

    }
}
