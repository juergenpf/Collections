/* See License.md in the solution root for license information.
 * File: Priority.cs
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class Priority
    {
        [TestMethod]
        public void TestChangeTopPriority()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            var I = (IPriorityQueueWithKeyMapping<int, string>) o1;
            var q = (IPriorityQueue<int, string>)o1; 
            Assert.IsNotNull(o1);
            const string letters = "ABCDEFGHIJ";
            for (int i = 0; i < letters.Length; i++)
            {
                o1.Add(i + 1, letters.Substring(i, 1));
            }
            q.ChangePriority(-1);
            var pick = o1.Peek;
            Assert.IsNotNull(pick);
            Assert.AreEqual(pick.Key, letters.Length-1);
            Assert.IsTrue(I.ContainsKey(-1));
        }

        [TestMethod]
        public void TestChangeInsidePriority()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            var I = (IPriorityQueueWithKeyMapping<int, string>) o1;
            var q = (IPriorityQueue<int, string>)o1;
            Assert.IsNotNull(o1);
            const string letters = "ABCDEFGHIJ";
            const int pickIndex = 5;
            for (int i = 0; i < letters.Length; i++)
            {
                o1.Add(i + 1, letters.Substring(i, 1));
            }
            I.ChangePriority(pickIndex,-1);
            var pick = o1.Peek;
            Assert.IsNotNull(pick);
            Assert.AreEqual(pick.Key, letters.Length);
            Assert.IsTrue(I.ContainsKey(-1));
            var element = o1[-1];
            Assert.AreEqual(element,letters.Substring(pickIndex-1,1));
        }

        [TestMethod]
        public void TestIndexedPriorityChange()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o);
            o.Add(2,"B");
            o.Add(1,"A");
            o.ChangePriority(2,-100);
            var top = o.Peek;
            Assert.AreEqual(top.Key,-100);
        }

        [TestMethod]
        public void TestIndexerChangePrioInterface()
        {
            var o1 = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o1);
            var I = (IPriorityQueueWithIndexing<int, TestValueClass>)o1;
            Assert.IsNotNull(I);
            o1.Add(2, "B");
            o1.Add(1, "A");
            I.ChangePriority(2,-100);
            var top = o1.Peek;
            Assert.AreEqual(top.Key, -100);
        }

        [TestMethod]
        public void TestIndexerChangeMappedPrioInterface()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(o1);
            var I = (IPriorityQueueWithKeyMapping<int, string>)o1;
            Assert.IsNotNull(I);
            o1.Add(2, "B");
            o1.Add(1, "A");
            I.ChangePriority(2, 100);
            var top = o1.Peek;
            Assert.AreEqual(top.Key, 1);
        }

        [TestMethod]
        public void TestIndexerChangeMappedPrioInterface2()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(o1);
            var I = (IPriorityQueueWithIndexing<int, string>)o1;
            Assert.IsNotNull(I);
            o1.Add(2, "B");
            o1.Add(1, "A");
            I.ChangePriority(2, 100);
            var top = I[2];
            Assert.AreEqual(top.Key, 100);
        }
    
    }
}
