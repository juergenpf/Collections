/* See License.md in the solution root for license information.
 * File: IPriorityQueueWithKeyMapping.cs
*/
using System;
using System.Collections.Generic;

namespace Collections.Generic
{
    /// <summary>
    /// This is an interface to a Priority Queue, where the Caller has some
    /// intrinsic knowledge about the mapping from the key values to the
    /// internal index of elements on the queue. This means especially, that
    /// he key must be unique in the queue (other than for general
    /// IPriorityQueue)
    /// </summary>
    /// <typeparam name="TK">The key type to use. Must implement IComparable`TK</typeparam>
    /// <typeparam name="TV">The value for the elements in the queue.</typeparam>
    public interface IPriorityQueueWithKeyMapping<TK, TV> 
        : IPriorityQueueWithIndexing<TK, TV> where TK : IComparable<TK>
    {
        /// <summary>
        /// Return the internal index of an element in the queue
        /// </summary>
        /// <param name="key">The index of the element in the queue</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the key is not in the queue</exception>
        /// <returns>The index of the element</returns>
        int Index(TK key);

        /// <summary>
        /// Check the existence of a key in the queue
        /// </summary>
        /// <param name="key">The key to lookup</param>
        /// <returns>True if the key exists, false otherwise</returns>
        bool ContainsKey(TK key);

        /// <summary>
        /// RemoveByIndex an element from the queue that's specified by its key
        /// </summary>
        /// <param name="key">The key of the element to be removed</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the key is not in the queue</exception>
        /// <returns>The removed KeyValuePair</returns>
        KeyValuePair<TK, TV> Dequeue(TK key);

        /// <summary>
        /// Change the priority of an element in the queue
        /// </summary>
        /// <param name="oldKey">The original priority (must exist)</param>
        /// <param name="newKey">The new priority</param>
        /// <exception cref="KeyNotFoundException">May be thrown if the oldKey is not in the queue</exception>
        void ChangePriority(TK oldKey, TK newKey);

    }
}
