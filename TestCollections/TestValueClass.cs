/* See License.md in the solution root for license information.
 * File: TestValueClass.cs
*/
namespace TestCollections
{
    public class TestValueClass
    {
        public int Index { get; private set; }
        public string Value { get; set; }

        public static int Callback(TestValueClass v, int newIndex)
        {
            var old = v.Index;
            if (newIndex >= 0)
                v.Index = newIndex;
            return old;
        }

        public static implicit operator TestValueClass(string s) => new TestValueClass {Index = -1, Value = s};
    }
}