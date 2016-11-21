using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Set<T> : IEnumerable<T> where T : class, IEquatable<T>
    {
        private T[] elements;
        private int capacity;
        private int defaultCapacity = 10;
        private int size;

        /// <summary>
        /// Initializes a new instance of the Set class that is empty.
        /// </summary>
        public Set()
        {
            elements = new T[defaultCapacity];
            capacity = defaultCapacity;
            size = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Set contains elements copied from the specified 
        /// collection
        /// </summary>
        /// <param name="array"></param>
        public Set(IEnumerable<T> array):this()
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            foreach (T element in array)
                Add(element);
        }

        /// <summary>
        ///  Determines whether set contains a specific value.
        /// </summary>
        /// <param name="x">Value to check.</param>
        /// <returns>True if contains value, false if doesn't contain.</returns>
        public bool Contains(T x) => elements.Contains(x);

        /// <summary>
        /// Adds an item to the set.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws if item already exists in set.
        /// </exception>
        /// <param name="x">Item to add.</param>
        public void Add(T x)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (Contains(x)) throw new ArgumentException($"Element {x} already exists");
            AddItem(x);
        }

        /// <summary>
        /// Removes item from the set.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Throws Set doesn't contain item.
        /// </exception>
        /// <param name="x">Item to remove.</param>
        public void Remove(T x)
        {
            if (!Contains(x))
                throw new ArgumentException($"Set doesn't contain {x}. Removing is impossible.");
            RemoveItem(x);
        }

        /// <summary>
        /// Result contains all elements that are present in set, 
        /// input set, or both.
        /// </summary>
        /// <param name="other">Instanse of Set.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when input parameter is null.
        /// </exception>
        /// <returns>All elements that are present in set, input set, or both</returns>
        public IEnumerable<T> UnionCustom(Set<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other)); 
            return this.Union(other);
        }

        /// <summary>
        /// Result contains only elements that are present in set 
        /// and in input set.
        /// </summary>
        /// <param name="other">Instanse of Set.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when input parameter is null.
        /// </exception>
        /// <returns>Elements that are present in set and in input set</returns>
        public IEnumerable<T> IntersectCustom(Set<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return this.Intersect(other);
        }

        /// <summary>
        /// Removes all elements in input set from set.
        /// </summary>
        /// <param name="other">Instance of set</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when input parameter is null.
        /// </exception>
        /// <returns>Set without elements in input set.</returns>
        public IEnumerable<T> ExceptCustom(Set<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return this.Except(other);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != default(T))
                    yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void AddItem(T x)
        {
            if (size == capacity)
            {
                capacity += defaultCapacity;
                Array.Resize(ref elements, capacity);
            }
            elements[size] = x;
            size++;
        }

        private void RemoveItem(T x)
        {
            for (int i = Array.IndexOf(elements, x); i < size; i++)
            {
                elements[i] = elements[i + 1];
            }
            size--;
        }
    }
}
