using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Queue<T>: IEnumerable<T>, IEnumerable
    {
        private T[] elements;
        private int head;
        private int tail;
        private const int defaultCapacity = 10;
        private int capacity;
        private int size;

        /// <summary>
        /// Initializes a new instance of the Queue<T> class that is empty 
        /// and has the default initial capacity.
        /// </summary>
        public Queue() 
        {
            elements = new T[defaultCapacity];
            head = 0;
            tail = 0;
            capacity = defaultCapacity;
            size = 0;
        }
        /// <summary>
        /// Adds an object to the end of the Queue<T>.
        /// </summary>
        /// <param name="element">Item to add.</param>
        public void Enqueue(T element)
        {
            if (size == capacity)
            {
                T[] nextQueue = new T[2 * capacity];
                Array.Copy(elements, 0, nextQueue, 0, elements.Length);
                elements = nextQueue;
                capacity *= 2;
            }
            size++;
            elements[tail++] = element;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Throws if queue is empty.
        /// </exception>
        /// <returns>The object at the beginning of the Queue.</returns>
        public T Dequeue()
        {
            if (size == 0)
                throw new InvalidOperationException($"Can't dequeue because the queue is empty.");
            T element = elements[head];
            elements[head++] = default(T);
            size--;
            return element;
        }

        /// <summary>
        /// Returns the object at the beginning of the Queue without removing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Throws if queue is empty.
        /// </exception>
        /// <returns>The object at the beginning of the Queue</returns>
        public T Peek()
        { 
            if (size == 0) 
                throw new InvalidOperationException($"Can't peek because the queue is empty.");
            return elements[head]; 
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private Queue<T> queue;
            private int index;

            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue;
                index = -1;
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// Throws if index is out of size.
            /// </exception>
            public T Current
            {
                get
                {
                    if (index == -1 || index == queue.size)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue.elements[index];
                }
            }

            object IEnumerator.Current => Current;

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>False if current the enumerator is positioned 
            /// after the last element in the collection.</returns>
            public bool MoveNext() => ++index < queue.size;

            void IEnumerator.Reset() { throw new NotSupportedException(); }

            void IDisposable.Dispose() { throw new NotSupportedException(); }
        }
    }
}
