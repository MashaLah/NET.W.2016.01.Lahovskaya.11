using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
using NUnit.Framework;

namespace Task2Tests
{
    [TestFixture]
    public class QueueTests
    {
        /// <summary>
        /// A test for Eneque().
        /// </summary>
        [TestCase(10, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(12, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        public void Eneque_ValidData_validResult(int n, int[] array)
        {
            Task2.Queue<int> queue = new Task2.Queue<int>();
            for (int i = 0; i < n; i++)
                queue.Enqueue(i);
            CollectionAssert.AreEquivalent(array,queue);
        }

        /// <summary>
        /// A test for Dequeue().
        /// </summary>
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void Dequeue_ValidData_ValidResult(int[] array, IEnumerable<int> collection)
        {
            Task2.Queue<int> queue = new Task2.Queue<int>(collection);
            queue.Dequeue();
            CollectionAssert.AreEquivalent(array,queue);
        }

        /// <summary>
        /// A test for Peek().
        /// </summary>
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },1)]
        public void Peek_ValidData_ValidResult(IEnumerable<int> collection, int expected)
        {
            Task2.Queue<int> queue = new Task2.Queue<int>(collection);
            int actual = queue.Peek();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Constructor with parameter.
        /// </summary>
        [Test]
        public void Constructor_Null_ThrowsException() =>
            Assert.Throws<ArgumentNullException>(() => new Task2.Queue<int>(null));

        /// <summary>
        /// A test for Dequeue().
        /// </summary>
        [Test]
        public void Dequeue_EmptyCollection_ThrowsException()
        {
            Task2.Queue<int> queue = new Task2.Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        /// <summary>
        /// A test for Peek().
        /// </summary>
        [Test]
        public void Peek_EmptyCollection_ThrowsException()
        {
            Task2.Queue<int> queue = new Task2.Queue<int>();
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }
    }
}
