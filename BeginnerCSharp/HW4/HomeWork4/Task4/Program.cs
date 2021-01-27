using System;
using static System.Console;
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Input a number for calculating it's fibonacci");
            var input = ReadLine().AsSpan();

            if (!int.TryParse(input, out var n))
            {
                WriteLine("incorrect number");
                return;
            }
            
            WriteLine($"Fibonacci of {n} is {Fibonacci(n)}");
            
            // Program Stop
            ReadLine();
        }

        private static int Fibonacci(int n) =>
            n switch
            {
                0 => 0,
                1 => 1,
                _ => Fibonacci(n - 1) + Fibonacci(n - 2)
            };
    }
}