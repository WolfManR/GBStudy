using System;
using System.Text;
using static System.Console;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Input something and i reverse it:");
            var input = ReadLine().AsSpan();
            var sb = new StringBuilder();
            for (var i = input.Length - 1; i >= 0; i--)
                sb.Append(input[i]);
            
            WriteLine($"Reverced:\n{sb}");
        }
    }
}