/* See License.md in the solution root for license information.
 * File: GetElements.cs
*/
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections.Generic;

namespace TestCollections
{
    [TestClass]
    public class GetElements
    {
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestPeekEmpty()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(o1);
            var top = o1.Peek;
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestIndexerOutOfRange()
        {
            var o1 = new BinaryHeapWithReverseMap<int, string>();
            Assert.IsNotNull(o1);
            o1.Add(1,"A");
            o1.Add(2,"B");
            var pick = o1[3];
        }
    }
}
