/* See License.md in the solution root for license information.
 * File: IPriorityQueue.cs
*/
using System;
using System.Collections.Generic;

namespace Collections.Generic
{
    /// <summary>
    /// The Interface to a priority queue. That is a queue where the elements are maintained in a way,
    /// that always the one with the smallest/largest (depending on the sort order) value is on the 
    /// head of the queue.
    /// </summary>
    /// <typeparam name="TK">The key type to use. Must implement IComparable`TK</typeparam>
    /// <typeparam name="TV">The value for the elements in the queue.</typeparam>
    public interface IPriorityQueue<TK,TV> where TK : IComparable<TK>
    {
        /// <summary>
        /// Is the queue empty?
        /// </summary>
        /// <value>True if the queue is empty, False otherwise.</value>
        bool IsEmpty
        {
            get;
        }

        /// <summary>
        /// Add a value with a specified key to the queue. There is no guaranteed ordering, with
        /// the one and only exception: the smallest/largets (depending on the sort order) is
        /// always on the head of the queue.
        /// </summary>
        /// <param name="key">The requested key for the new value.</param>
        /// <param name="value">The value to add to the queue.</param>
        void Enqueue(TK key, TV value);
        
        /// <summary>
        /// Get the head element in the queue, but don't remove it. Depending on the sort
        /// order this is the smallest or largest element in the queue.
        /// </summary>
        /// <exception cref="KeyNotFoundException">May be thrown if the queue is empty.</exception>
        /// <value>The head element in the queue.</value>
        KeyValuePair<TK,TV> Peek
        {
            get;
        }

        /// <summary>
        /// Get the head element in the queue and remove it from the queue.
        /// Depending on the sort order this is the smallest or largest element in the queue.
        /// The queue is internally rearranged to make sure, that now the new smallest/largest
        /// element is on the head of the queue.
        /// </summary>
        /// <exception cref="KeyNotFoundException">May be thrown if the queue is empty.</exception>
        /// <value>The head element in the queue.</value>
        KeyValuePair<TK, TV> Dequeue();

        /// <summary>
        /// Changes the key of the head element in the queue. This most likely
        /// will reposition the element in the queue and it's perhaps no longer the
        /// head element after that operation.
        /// </summary>
        /// <param name="newKey">The new key for the first element.</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the queue is empty.</exception>
        void ChangePriority(TK newKey);
    }
}
