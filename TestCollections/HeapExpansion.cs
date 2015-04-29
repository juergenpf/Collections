/* See License.md in the solution root for license information.
 * File: HeapExpansion.cs
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class HeapExpansion
    {
        [TestMethod]
        public void TestHeapExpansion()
        {
            const int TestCapacity = 5;
            var o1 = new BinaryHeapWithReverseMap<int, string>(SortOrder.Descending, TestCapacity);
            Assert.IsNotNull(o1);
            for (int i = 0; i < 100*TestCapacity; i++)
            {
                o1.Add(i,i.ToString());
            }
        }
    }
}
