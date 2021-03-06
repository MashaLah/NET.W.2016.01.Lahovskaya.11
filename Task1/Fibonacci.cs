﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Fibonacci
    {
        /// <summary>
        /// Generates Fibonacci numbers.
        /// </summary>
        /// <param name="n">Number of Fibonacci numbers</param>
        /// <exception  cref="ArgumentOutOfRangeException">
        /// Throws if n<2.
        /// </exception>
        /// <returns>Chain of Fibonacci numbers.</returns>
        public static IEnumerable<int> GenerateFibonacciNumbers(int n)
        {
            if (n < 2) throw new ArgumentOutOfRangeException(nameof(n));
            int previous = 0, current = 1;
            int i = 0;
            while (i < n)
            {
                yield return previous;
                int next = previous + current;
                previous = current;
                current = next;
                i++;
            }
        }
    }
}
