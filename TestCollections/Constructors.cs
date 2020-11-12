/* See License.md in the solution root for license information.
 * File: Constructors.cs
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class Constructors
    {
        [TestMethod]
        public void TestBaseDefaultConstructor()
        {
            var o = new BinaryHeap<int, string>();
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count,0);
        }

        [TestMethod]
        public void TestBaseDefaultConstructorWithCapacity()
        {
            var o = new BinaryHeap<int, string>(100);
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count, 0);
        }

        [TestMethod]
        public void TestBaseDefaultConstructorWithSort()
        {
            var o = new BinaryHeap<int, string>(SortOrder.Descending);
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count, 0);
        }

        [TestMethod]
        public void TestDefaultConstructor()
        {
            var o = new BinaryHeapWithReverseMap<int,string>();
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count, 0);
        }

        [TestMethod]
        public void TestDefaultConstructorSort()
        {
            var o = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void InvalidCapacity()
        {
            _ = new BinaryHeapWithReverseMap<int, string>(1);
        }

        [TestMethod]
        public void TestConstructorSortAndCapacity()
        {
            var o = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending, 1000);
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidCapacity2()
        {
            _ = new BinaryHeapWithReverseMap<int, string>(SortOrder.Ascending, 0);
        }

        [TestMethod]
        public void TestConstructorSort()
        {
            var o = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending);
            Assert.IsNotNull(o);
            Assert.AreEqual(o.Count, 0);
        }
    }
}
