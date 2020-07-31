/* See License.md in the solution root for license information.
 * File: ConstructorsWithIndex.cs
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class ConstructorsWithIndex
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback);
            Assert.IsNotNull(o);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidCapacity()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback,1);
        }

        [TestMethod]
        public void TestConstructorSortAndCapacity()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback, SortOrder.Descending, 1000);
            Assert.IsNotNull(o);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidCapacity2()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback, SortOrder.Ascending, 0);
        }

        [TestMethod]
        public void TestConstructorSort()
        {
            var o = new BinaryHeapWithCallback<int, TestValueClass>(
                TestValueClass.Callback, SortOrder.Ascending);
            Assert.IsNotNull(o);
        }
    }
}
