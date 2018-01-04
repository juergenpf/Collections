/* See License.md in the solution root for license information.
 * File: BinaryHeapWithReverseMap.cs
*/
using System;
using System.Collections.Generic;

namespace Collections.Generic
{
    /// <summary>
    /// This is a conveniance class where in the heap we maintain a dictionary to map the
    /// keys to their internal index values. Because this dictionary needs ro be maintained,
    /// the implementation is less efficient than the base class. It also means, that the
    /// queue can also contain a key only once.
    /// But we get some conveniance without any assumptions for the TV value class like with
    /// the BinaryHeapWithCallback class.
    /// </summary>
    /// <typeparam name="TK">The type of the key, must implement IComparable`TK</typeparam>
    /// <typeparam name="TV">The type of the elements to store</typeparam>
    public class BinaryHeapWithReverseMap<TK, TV> : 
        BinaryHeap<TK, TV>, IPriorityQueueWithKeyMapping<TK,TV> 
        where TK : IComparable<TK>
    {
        private readonly Dictionary<TK, int> _reverseMap;         // reverse mapping into the heap
        private readonly IPriorityQueueWithKeyMapping<TK, TV> _i; // Myself as an interface
        private readonly IPriorityQueueWithIndexing<TK, TV> _ii;  // Myself as the base interface 

        #region Constructors
        /// <summary>
        /// Create a heap with a default capacity and ascending sort order.
        /// </summary>
        public BinaryHeapWithReverseMap() : this(DefaultCapacity)
        { }

        /// <summary>
        /// Create a new heap with the specified sort order and default capacity.
        /// </summary>
        /// <param name="sortOrder">The sort order (Ascending or Descending)</param>
        public BinaryHeapWithReverseMap(SortOrder sortOrder) : this(sortOrder, DefaultCapacity)
        { }

        /// <summary>
        /// Create a new heap with the specified capacity and sort order.
        /// </summary>
        /// <param name="sortOrder">The sort order (Ascending or Descending)</param>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the capacity is less than 2.</exception>
        public BinaryHeapWithReverseMap(SortOrder sortOrder, int capacity) : base(sortOrder,capacity)
        {
            _reverseMap = new Dictionary<TK, int>();
            _i = (IPriorityQueueWithKeyMapping<TK, TV>) this;
            _ii = (IPriorityQueueWithIndexing<TK, TV>) this;
        }

        /// <summary>
        /// Create a new heap with the specified capacity and default ascending sort order
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the capacity is less than 2.</exception>
        public BinaryHeapWithReverseMap(int capacity) : this(SortOrder.Ascending, capacity)
        { }
        #endregion

        protected override void AssignToIndex(int lhs, KeyValuePair<TK,TV> rhs) {
            base.AssignToIndex(lhs,rhs);
            if (_i.ContainsKey(rhs.Key))
            {
                _reverseMap[rhs.Key] = lhs;
            }
            else
                _reverseMap.Add(rhs.Key, lhs);
        }

        /// <summary>
        /// Add a new element to the heap. If the capacity gets exceeded the heap will be expanded.
        /// </summary>
        /// <param name="item">The KeyValuePair to add to the heap.</param>
        /// <exception cref="InvalidOperationException">May be thrown if the key is duplicate.</exception>
        public override void Add(KeyValuePair<TK, TV> item)
        {
            if (_reverseMap.ContainsKey(item.Key))
                throw new InvalidOperationException(Properties.Resource.DUPLICATE_KEY);
            base.Add(item);
        }

        /// <summary>
        /// Retrieve the queue element associated with a specific key
        /// </summary>
        /// <param name="key">The key of the element</param>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the heap is empty.</exception>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty.</exception>
        /// <returns>The element belonging to this key</returns>
        public TV this[TK key]
        {
            get
            {
                return base[_i.Index(key)].Value;
            }
        }

        /// <summary>
        /// RemoveByIndex all elements from the heap.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            _reverseMap.Clear();
        }

        /// <summary>
        /// RemoveByIndex an element from the queue that's specified by its key
        /// </summary>
        /// <param name="key">The key of the element to be removed</param>
        /// <exception cref="InvalidOperationException">May be thrown if the heap is empty.</exception>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty.</exception>
        /// <returns>The removed element</returns>
        public KeyValuePair<TK, TV> Remove(TK key)
        {
            return _i.Dequeue(key);
        }


        #region Implementation of IPriorityQueueWithKeyMapping
        public bool ContainsKey(TK key)
        {
            return _reverseMap.ContainsKey(key);
        }

        public int Index(TK key)
        {
            if (!_reverseMap.ContainsKey(key))
                throw new KeyNotFoundException(Properties.Resource.KEY_NOT_FOUND);
            return _reverseMap[key];
        }

        KeyValuePair<TK, TV> IPriorityQueueWithKeyMapping<TK, TV>.Dequeue(TK key)
        {
            return RemoveByIndex(_i.Index(key));
        }

        void IPriorityQueueWithKeyMapping<TK, TV>.ChangePriority(TK oldKey, TK newKey)
        {
            Add(newKey,RemoveByIndex(_i.Index(oldKey)).Value);
        }

        #endregion

        #region Explicit implementation of IPriorityQueueWithIndexing
        KeyValuePair<TK, TV> IPriorityQueueWithIndexing<TK,TV>.Dequeue(int index)
        {
            return RemoveByIndex(index);
        }

        KeyValuePair<TK, TV> IPriorityQueueWithIndexing<TK,TV>.this[int index]
        {
            get { return this[index]; }
        }

        void IPriorityQueueWithIndexing<TK,TV>.ChangePriority(int index, TK newPriority)
        {
            Add(newPriority, RemoveByIndex(index).Value);
        }
        #endregion
    }
}