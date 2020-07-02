/* See License.md in the solution root for license information.
 * File: IPriorityQueueWithIndexing.cs
*/
using System;
using System.Collections.Generic;

namespace Collections.Generic
{
    /// <summary>
    /// This is an interface to an IPriorityKey, where the Caller has some intrinsic knowledge about
    /// the internal index of elements on the queue and can use that index to operate on the queue
    /// </summary>
    /// <typeparam name="TK">The key type to use. Must implement IComparable`TK</typeparam>
    /// <typeparam name="TV">The value for the elements in the queue.</typeparam>
    public interface IPriorityQueueWithIndexing<TK, TV> : IPriorityQueue<TK, TV> where TK : IComparable<TK>
    {
        /// <summary>
        /// Remove the element which is on the speified position in the queue.
        /// </summary>
        /// <param name="index">The index of the element in the queue</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the queue is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the inddex is invalid.</exception>
        /// <returns></returns>
        KeyValuePair<TK, TV> Dequeue(int index);

        /// <summary>
        /// Get the KeyValuePair from the queue. An exception will be thrown if the element
        /// isn't in the queue.
        /// </summary>
        /// <param name="index">The index of the pair in the queue</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the queue is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the inddex is invalid.</exception>
        /// <returns>The requested KeyValuePair</returns>
        KeyValuePair<TK, TV> this[int index] { get; }

        /// <summary>
        /// Change the key of an element in the queue. 
        /// </summary>
        /// <param name="index">The index of the element in the queue</param>
        /// <param name="newKey">The new key</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the queue is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">May be thrown if the inddex is invalid.</exception>
        void ChangePriority(int index, TK newKey);
    }
}
