/* See License.md in the solution root for license information.
 * File: TestValueClass.cs
*/
namespace TestCollections
{
    public class TestValueClass
    {
        public int index { get; set; }
        public string value { get; set; }

        public static int Callback(TestValueClass v, int newIndex)
        {
            int old = v.index;
            if (newIndex >= 0)
                v.index = newIndex;
            return old;
        }

        public static implicit operator TestValueClass(string s)
        {
            return new TestValueClass {index = -1, value = s};
        }
    }
}