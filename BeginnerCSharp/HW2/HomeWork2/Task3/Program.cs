using System;
using static System.Console;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Please input number");
            var userNumber = ReadLine().AsSpan();

            if (!int.TryParse(userNumber, out var number))
            {
                WriteLine("Not Correct input");
                return;
            }
            
            WriteLine("Your number is {0}", number % 2 == 0 ? "even" : "odd");
            
            // Program Stop
            ReadLine();
        }
    }
}