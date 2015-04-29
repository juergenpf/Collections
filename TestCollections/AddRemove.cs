/* See License.md in the solution root for license information.
 * File: AddRemove.cs
*/
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class AddRemove
    {
        [TestMethod]
        public void TestAdd()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Ascending, 10);
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
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Ascending, 10);
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
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending, 10);
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
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending, 10);
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
            var o1 = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(o1);
            o1.Add(3,"C");
            o1.Add(2,"B");
            o1.Add(1,"A");
            var r = o1.Remove(2);
            Assert.IsNotNull(r);
            Assert.AreEqual(r.Key,2);
            Assert.AreEqual(o1.Count,2);
            var top = o1.Peek;
            Assert.IsNotNull(top);
            Assert.AreEqual(top.Key,1);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestRemoveFromEmpty()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            var pick = o1.Remove();
        }

        [TestMethod]
        public void TestRemoveFromInside()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            Assert.IsNotNull(o1);
            const string letters = "ABCDEFGHIJ";
            for (int i = 0; i < letters.Length; i++)
            {
                o1.Add(i+1,letters.Substring(i,1));
            }
            var pick = o1.Remove(2);
            Assert.IsNotNull(pick);
            Assert.AreEqual(pick.Key,2);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestRemoveFromInsideWithNonExistentKey()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
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
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
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
            var o1 = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(o1);
            o1.Add(1,"A");
            o1.Add(2,"B");
            o1.Clear();
            Assert.AreEqual(o1.Count,0);
        }

        [TestMethod]
        public void TestUseAfterClear()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>();
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
        public void TestSamePriority()
        {
            var h = new BinaryHeap<int, string>();
            Assert.IsNotNull(h);
            h.Add(3,"C1");
            h.Add(2,"B1");
            h.Add(1,"A1");
            h.Add(3, "C2");
            h.Add(2, "B2");
            h.Add(1, "A2");
            h.Add(3, "C3");
            h.Add(2, "B3");
            h.Add(1, "A3");
            Assert.AreEqual(h.Count,9);
            for (var i = 0; i < 9; i++)
            {
                var top = h.Remove();
                int j = 1 + i/3;
                Assert.AreEqual(j,top.Key);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSamePriorityWithMappedKeyHeap()
        {
            var h = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(h);
            h.Add(2,"B");
            h.Add(1,"A");
            h.Add(2,"C");
        }

        [TestMethod]
        public void TestIndexer()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            Assert.IsNotNull(o1);
            var I = (IPriorityQueueWithKeyMapping<int, string>)o1;
            Assert.IsNotNull(I);
            o1.Add(1, "A");
            o1.Add(2, "B");
            var top = I[2];
            Assert.AreEqual(top.Key, 1);
        }

        [TestMethod]
        public void TestDequeueInterface()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            Assert.IsNotNull(o1);
            var I = (IPriorityQueueWithKeyMapping<int, string>)o1;
            Assert.IsNotNull(I);
            o1.Add(1, "A");
            o1.Add(2, "B");
            var top = I.Dequeue(2);
            Assert.AreEqual(top.Key, 2);
        }

        [TestMethod]
        public void TestSimpleEnqueueDequeue()
        {
            var o = new BinaryHeap<int, string>();
            Assert.IsNotNull(o);
            var I = (IPriorityQueue<int, string>) o;
            Assert.IsNotNull(I);
            I.Enqueue(2,"B");
            I.Enqueue(1,"A");
            var top = I.Dequeue();
            Assert.AreEqual(top.Key,1);
            Assert.AreEqual(o.Count,1);
            top = I.Dequeue();
            Assert.AreEqual(top.Key, 2);
            Assert.AreEqual(o.Count, 0);
        }
    }
}
