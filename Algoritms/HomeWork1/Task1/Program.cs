using System;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            (int number, bool expected)[] testCases =
            {
                (2,true),
                (12,false),
                (-2,true),
                (30,false),
            };

            foreach (var (number, expected) in testCases)
            {
                var result = IsPrimeNumber(number);
                var assert = result == expected;
                Console.WriteLine($"Number: {number}, Result: {result}, Assert: {assert}");
            }
            
            
            Console.WriteLine(IsPrimeNumber(1)?"Prime number":"Not a prime number");
            
            // Program Stop
            Console.WriteLine("Work Done");
            Console.ReadLine();
        }
        
        public static bool IsPrimeNumber(int n)
        {
            var d = 0;
            var i = 2;
            
            while (i<n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }

            return d == 0;
        }
    }
}