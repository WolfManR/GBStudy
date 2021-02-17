using System;

namespace Task3
{
    public class Program
    {
        static void Main(string[] args)
        {
            (int number,int expected)[] testCases =
            {
                (0,0),
                (1,1),
                (2,1),
                (3,2),
                (4,3),
                (5,5),
            };

            foreach (var testCase in testCases)
            {
                var recursive = RecursiveFibonacci(testCase.number);
                var loop = LoopFibonacci(testCase.number);
                var assert = recursive == loop && recursive == testCase.expected;
                Console.WriteLine($"Number {testCase.number}, Recursive {recursive}, Loop {loop}, Assert {assert}");
            }
            
            // Program Stop
            Console.WriteLine("Work Done");
            Console.ReadLine();
        }


        public static int RecursiveFibonacci(int number) =>
            number switch
            {
                0 => 0,
                1 => 1,
                _ => RecursiveFibonacci(number - 2) + RecursiveFibonacci(number - 1)
            };

        public static int LoopFibonacci(int number)
        {
            if (number == 0) return 0;
            if (number == 1) return 1;

            var prev = 0;
            var cur = 1;
            
            for (var i = 2; i <= number; i++)
            {
                var temp = prev + cur;
                prev = cur;
                cur = temp;
            }

            return cur;
        }
    }
}