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

        public Queue(IEnumerable<T> array) :this()
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            foreach (T element in array)
                Enqueue(element);
        }

        /// <summary>
        /// Adds an object to the end of the Queue<T>.
        /// </summary>
        /// <param name="element">Item to add.</param>
        public void Enqueue(T element)
        {
            if (size == capacity)
            {
                T[] nextQueue = new T[capacity + defaultCapacity];
                if (head < tail)
                    Array.Copy(elements, head, nextQueue, 0, size);
                else
                {
                    Array.Copy(elements, head, nextQueue, 0, capacity - head);
                    Array.Copy(elements, 0, nextQueue, capacity - head, tail);
                }
                elements = nextQueue;
                head = 0;
                tail = size;
                capacity += defaultCapacity;
            }
            size++;
            elements[tail] = element;
            if (size == capacity && tail == capacity - 1)
                tail++;
            else
                tail = ++tail % capacity;
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
            elements[head] = default(T);
            head = ++head % capacity;
            size--;
            if (tail == capacity) tail = 0; 
            return element;
            //return elements[++head % capacity];
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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        

        private class QueueEnumerator : IEnumerator<T>
        {
            private readonly Queue<T> queue;
            private int index;
            private int count;

            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue;
                index = queue.head - 1;
                count = 0;
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// Throws if index is out of range.
            /// </exception>
            public T Current
            {
                get
                {
                    return queue.elements[index];
                }
            }

            object IEnumerator.Current => Current;

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>False if current the enumerator is positioned 
            /// after the last element in the collection.</returns>
            public bool MoveNext()
            {
                index++;
                count++;
                if (count > queue.size) return false;
                if (index == queue.capacity && queue.head >= queue.tail) index = 0;
                if (queue.head >= queue.tail) return index < queue.capacity;
                return index < queue.tail;
            }

            void IEnumerator.Reset() { }

            void IDisposable.Dispose() { }
        }
    }
}
