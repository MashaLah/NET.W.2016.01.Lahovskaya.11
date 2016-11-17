using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Set<T> : IEnumerable<T> where T : class, IComparable<T>
    {
        private T[] elements;

        /// <summary>
        /// Initializes a new instance of the Set class that is empty.
        /// </summary>
        public Set()
        {
            elements = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of the Set contains elements copied from the specified 
        /// collection
        /// </summary>
        /// <param name="array"></param>
        public Set(params T[] array)
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
        public Set<T> Union(Set<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other)); 
            Set<T> result = new Set<T>(elements);
            foreach (T element in other)
            {
                if(!result.Contains(element))
                    result.AddItem(element);
            }
            return result;   
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
        public Set<T> Intersect(Set<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            Set<T> result = new Set<T>();
            foreach (T element in other)
            {
                if (Contains(element))
                    result.AddItem(element);
            }
            return result;
        }

        /// <summary>
        /// Removes all elements in input set from set.
        /// </summary>
        /// <param name="other">Instance of set</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when input parameter is null.
        /// </exception>
        /// <returns>Set without elements in input set.</returns>
        public Set<T> Except(Set<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            Set<T> result = new Set<T>(elements);
            foreach (T element in other)
            {
                if (Contains(element))
                    result.RemoveItem(element);
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
                yield return elements[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void AddItem(T x)
        {
            Array.Resize(ref elements, elements.Length + 1);
            elements[elements.Length - 1] = x;
        }

        private void RemoveItem(T x)
        {
            for (int i = Array.IndexOf(elements, x); i < elements.Length; i++)
            {
                elements[i] = elements[i + 1];
            }
            Array.Resize(ref elements, elements.Length - 1);
        }
    }
}
