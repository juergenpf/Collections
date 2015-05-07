/* See License.md in the solution root for license information.
 * File: BinaryHeap.cs
*/
using System;
using System.Collections.Generic;

namespace Collections.Generic
{
    /// <summary>
    /// The sortorder for the heap.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// The smallest elements comes first
        /// </summary>
        Ascending,
        /// <summary>
        /// The largest element comes first
        /// </summary>
        Descending
    };

    /// <summary>
    /// A binary heap is a container that allows the efficient storing of elements that have
    /// a comparable key in a way, that the element with the smallest key is always the first
    /// element in the heap. This property is maintained even when this element gets removed.
    /// Only the removal of this first element is allowed.
    /// </summary>
    /// <typeparam name="TK">The type of the key, must implement IComparable`TK</typeparam>
    /// <typeparam name="TV">The type of the elements to store</typeparam>
    public class BinaryHeap<TK, TV> : IPriorityQueue<TK, TV>
        where TK : IComparable<TK>
    {
        #region Constants for the implementation
        protected const int DefaultCapacity = 64;
        protected const SortOrder DefaultSortOrder = SortOrder.Ascending;
        protected const int MinimumCapacity = 2;
        #endregion

        private int _capacity;                      // The size of the initial junk
        private KeyValuePair<TK, TV>[] _heapArr;    // Typesafe array of heap elements
        private readonly SortOrder _sortOrder;      // The sort order for the heap

        #region Constructors
        /// <summary>
        /// Create a heap with a default capacity and ascending sort order.
        /// </summary>
        public BinaryHeap() : this(DefaultCapacity)
        { }

        /// <summary>
        /// Create a new heap with the specified sort order and default capacity.
        /// </summary>
        /// <param name="sortOrder">The sort order (Ascending or Descending)</param>
        public BinaryHeap(SortOrder sortOrder) : this(sortOrder, DefaultCapacity)
        { }

        /// <summary>
        /// Create a new heap with the specified capacity and sort order.
        /// </summary>
        /// <param name="sortOrder">The sort order (Ascending or Descending)</param>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the capacity is less than 2.</exception>
        public BinaryHeap(SortOrder sortOrder, int capacity)
        {
            if (capacity < MinimumCapacity)
            {
                throw new ArgumentOutOfRangeException(Properties.Resources.INVALID_CAPACITY);
            }
            _sortOrder = sortOrder;
            Count     = 0;
            _capacity  = capacity;
            _heapArr   = new KeyValuePair<TK, TV>[capacity + 1];
        }

        /// <summary>
        /// Create a new heap with the specified capacity and default ascending sort order
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the capacity is less than 2.</exception>
        public BinaryHeap(int capacity) : this(DefaultSortOrder, capacity)
        { }
        #endregion

        /// <summary>
        /// How many elements are in the heap?
        /// </summary>
        /// <value>The number of elements.</value>
        public int Count { get; private set; }

        private void ValidateIndex(int index)
        {
            if (Count==0)
                throw new KeyNotFoundException(Properties.Resources.EMPTY_HEAP);
            if (index < 1 || index > Count)
                throw new IndexOutOfRangeException(Properties.Resources.ELEMENT_NOT_FOUND);
        }

        /// <summary>
        /// Get/Set the KeyValuePair in the inernal array representing the heap
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the heap is empty</exception>
        /// <returns>The element</returns>
        protected KeyValuePair<TK, TV> this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _heapArr[index];
            }
            private set
            {
                ValidateIndex(index);
                _heapArr[index] = value;
            }
        }

        /// <summary>
        /// Compare two keys
        /// </summary>
        /// <param name="lhs">The left key</param>
        /// <param name="rhs">The right key</param>
        /// <returns>-1 if lhs less than rhs, 0 if lhs==rhs, 1 if lhs greater than rhs</returns>
        protected int Compare(TK lhs, TK rhs)
        {
            var res = lhs.CompareTo(rhs);
            if (SortOrder.Descending == _sortOrder)
                return (-res);
            else
                return (res);
        }

        /// <summary>
        /// Is this heap empty?
        /// </summary>
        /// <value>True if the heap is empty, False otherwise.</value>
        public bool IsEmpty
        {
            get
            {
                return (Count == 0);
            }
        }

        private bool IsFull
        {
            get
            {
                return (Count == _capacity);
            }
        }

        /// <summary>
        /// Get the first element from the heap but don't remove it.
        /// </summary>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the heap is empty</exception>
        /// <value>The smallest or largest element in the heap, depending on the sort order.</value>
        public KeyValuePair<TK, TV> Peek
        {
            get
            {
                return this[1];
            }
        }

        private void ExpandHeap()
        {
            var newCapacity = _capacity << 1;
            var newS = new KeyValuePair<TK, TV>[newCapacity + 1];
            _heapArr.CopyTo(newS, 0);
            _capacity = newCapacity;
            _heapArr = newS;
        }

        /// <summary>
        /// Assign an element to an indexed position in the internal heap array
        /// </summary>
        /// <param name="lhs">The index in the heap array</param>
        /// <param name="rhs">The element to assign</param>
        protected virtual void AssignToIndex(int lhs, KeyValuePair<TK,TV> rhs) {
            this[lhs] = rhs;
        }

        /// <summary>
        /// Add a new element to the heap. If the capacity gets exceeded the heap will be expanded.
        /// </summary>
        /// <param name="item">The KeyValuePair to add to the heap.</param>
        public virtual void Add(KeyValuePair<TK, TV> item)
        {
            if (IsFull)
                ExpandHeap();
            Count += 1;
            AssignToIndex(Count, item);
            PercolateUp(Count);
        }

        /// <summary>
        /// Add a new element with the specified key.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The element to add.</param>
        public void Add(TK key, TV value)
        {
            var e = new KeyValuePair<TK, TV>(key, value);
            Add(e);
        }

        /// <summary>
        /// Remove the element which is on the speified position in the heap
        /// </summary>
        /// <param name="index">The index of the element in the internal array</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the heap is empty</exception>
        /// <returns>The KeyValuePair that was removed</returns>
        protected KeyValuePair<TK,TV> RemoveByIndex(int index)
        {
            var root = this[index];
            var x = this[Count];
            AssignToIndex(index, x);
            Count--;
            if (index <= Count)
            {
                if (index > 1 && Compare(x.Key, this[index / 2].Key) < 0)
                {
                    PercolateUp(index);
                }
                else
                {
                    PercolateDown(index);
                }
            }
            return root;
        }

        /// <summary>
        /// RemoveByIndex all elements from the heap.
        /// </summary>
        public virtual void Clear()
        {
            Count    = 0;
            _capacity = DefaultCapacity;
            _heapArr  = new KeyValuePair<TK, TV>[_capacity + 1];
        }

        /// <summary>
        /// Get the first element from the heap an remove it.
        /// </summary>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty.</exception>
        /// <returns>The first element from the heap. This is the smallest or largest depending on the sort order.</returns>
        public KeyValuePair<TK, TV> Remove()
        {
            var root = this[1];
            var last = this[Count];
            if (--Count > 0)
            {
                AssignToIndex(1, last);
                PercolateDown(1);
            }
            return root;
        }

        private void PercolateDown(int hole)
        {
            int child;
            var tmp = this[hole];

            for (; hole * 2 <= Count; hole = child)
            {
                child = hole * 2;
                if (child != Count && Compare(this[child + 1].Key, this[child].Key) < 0)
                    child++;
                if (Compare(this[child].Key, tmp.Key) < 0)
                {
                    AssignToIndex(hole, this[child]);
                }
                else
                {
                    break;
                }
            }
            AssignToIndex(hole, tmp);
        }

        private void PercolateUp(int hole)
        {
            var tmp = this[hole];
            for (; hole > 1 && Compare(tmp.Key, this[hole / 2].Key) < 0; hole /= 2)
            {
                AssignToIndex(hole, this[hole / 2]);
            }
            AssignToIndex(hole, tmp);
        }

        #region IPriorityQueue implementation
        public void ChangePriority(TK priority)
        {
            Add(priority, Remove().Value);            
        }


        public void Enqueue(TK key, TV value)
        {
            Add(key,value);
        }

        public KeyValuePair<TK, TV> Dequeue()
        {
            return Remove();
        }
        #endregion
    }
}