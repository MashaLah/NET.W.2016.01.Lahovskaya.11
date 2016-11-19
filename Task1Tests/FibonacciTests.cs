using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task1.Fibonacci;
using NUnit.Framework;

namespace Task1Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        public void GenerateFibonacciNumbers_ValidData_ValidResult()
        {
            foreach (int i in GenerateFibonacciNumbers(5))
            {
                Console.Write($"{i} ");
            }
        }

        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(1)]
        public void GenerateFibonacciNumbers_InvalidData_ThrowException(int n)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                foreach (int i in GenerateFibonacciNumbers(n))
                {
                    
                }
            });
        }
    }
}
