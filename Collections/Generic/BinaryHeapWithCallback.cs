/* See License.md in the solution root for license information.
 * File: BinaryHeapWithCallback.cs
*/
using System;
using System.Collections.Generic;

namespace Collections.Generic
{
    /// <summary>
    /// This is a binary heap where the TV value class provides a callback to maintain the
    /// internal heap-index value. This allows for an efficient implementation of a binary
    /// heap where we can remove any element from the heap - instead of just the first one -
    /// and to retrieve the Key that has been used to store an element in the heap.
    /// </summary>
    /// <typeparam name="TK">The type of the key, must implement IComparable`TK</typeparam>
    /// <typeparam name="TV">The type of the elements to store</typeparam>
    public class BinaryHeapWithCallback<TK, TV> :
        BinaryHeap<TK, TV>, IPriorityQueueWithIndexing<TK, TV> where TK : IComparable<TK>
    {
        /// <summary>
        /// This callback assumes, that a TV value can somehow store the value
        /// of our internal index into the heap array. If we use a negative newValue,
        /// the value must not be stored.
        /// </summary>
        /// <param name="value">The TV object that we reference</param>
        /// <param name="newValue">The newValue to store. If negative, don't store</param>
        /// <returns>The previous value stored.</returns>
        public delegate int IndexReferencer(TV value, int newValue);

        #region Constructors
        private readonly IndexReferencer _indexReferencer; // The callback to reference the index in the heap

        /// <summary>
        /// Create a heap with a default capacity and ascending sort order.
        /// </summary>
        /// <param name="indexReferencer">The callback to store the heap-index</param>
        public BinaryHeapWithCallback(IndexReferencer indexReferencer)
            : this(indexReferencer, DefaultSortOrder, DefaultCapacity)
        { }

        /// <summary>
        /// Create a new heap with the specified sort order and default capacity.
        /// </summary>
        /// <param name="indexReferencer">The callback to store the heap-index</param>
        /// <param name="sortOrder">The sort order (Ascending or Descending)</param>
        public BinaryHeapWithCallback(IndexReferencer indexReferencer, SortOrder sortOrder)
            : this(indexReferencer, sortOrder, DefaultCapacity)
        { }

        /// <summary>
        /// Create a new heap with the specified capacity and sort order.
        /// </summary>
        /// <param name="indexReferencer">The callback to store the heap-index</param>
        /// <param name="sortOrder">The sort order (Ascending or Descending)</param>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the capacity is less than 2.</exception>
        public BinaryHeapWithCallback(IndexReferencer indexReferencer, SortOrder sortOrder, int capacity)
            : base(sortOrder, capacity)
        {
            _indexReferencer = indexReferencer;
        }

        /// <summary>
        /// Create a new heap with the specified capacity and default ascending sort order
        /// </summary>
        /// <param name="indexReferencer">The callback to store the heap-index</param>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the capacity is less than 2.</exception>
        public BinaryHeapWithCallback(IndexReferencer indexReferencer, int capacity)
            : this(indexReferencer, DefaultSortOrder, capacity)
        {
        }
        #endregion

        /// <inheritdoc/>
        protected override void AssignToIndex(int lhs, KeyValuePair<TK, TV> rhs)
        {
            base.AssignToIndex(lhs, rhs);
            // The callback stores the new index back into the value object
            _indexReferencer(rhs.Value, lhs);
        }

        /// <summary>
        /// Remove the element which is on the speified position in the heap.
        /// We typically know that index, because the callback will store it
        /// in our TV value object.
        /// </summary>
        /// <param name="index">The index of the element in the heap</param>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the index is out of range</exception>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty</exception>
        /// <returns>The removed KeyValuePair</returns>
        public KeyValuePair<TK, TV> Remove(int index)
        {
            return RemoveByIndex(index);
        }

        /// <summary>
        /// Get the KeyValuePair from the heap. An exception will be thrown if the element
        /// isn't in the heap.
        /// </summary>
        /// <param name="index">The index of the pair in the heap</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the index is out of range</exception>
        /// <returns>The requested KeyValuePair</returns>
        public KeyValuePair<TK, TV> Get(int index)
        {
            return this[index];
        }

        /// <summary>
        /// Change the key of an element on the heap.
        /// </summary>
        /// <param name="index">The index of the element in the heap</param>
        /// <param name="newPriority">The new key</param>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the index is out of range</exception>
        /// <exception cref="KeyNotFoundException">May be thrown if the heap is empty</exception>
        public void ChangePriority(int index, TK newPriority)
        {
            Add(newPriority, Remove(index).Value);
        }

        #region Implementation of IPriorityQueueWithIndexing
        KeyValuePair<TK, TV> IPriorityQueueWithIndexing<TK,TV>.this[int index]
        {
            get { return this[index]; }
        }

        KeyValuePair<TK, TV> IPriorityQueueWithIndexing<TK, TV>.Dequeue(int index)
        {
            return Remove(index);
        }
        #endregion
    }
}
