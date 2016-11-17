using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task1.Fibonacci;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in GenerateFibonacciNumbers(10))
            {
                Console.Write($"{i} ");
            }
            Console.ReadLine();
        }
    }
}
