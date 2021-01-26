using System;
using System.Globalization;
using static System.Console;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(@"Input numbers in one line, separating with ',', 
if you input float number to separate float's number's from integer's use '.' instead of ','");
            var input = ReadLine();
            
            if (input is null)
            {
                WriteLine("Incorrect input");
                return;
            }
            
            var numberStrings = input.Split(',',StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;
            for (var i = 0; i < numberStrings.Length; i++)
            {
                if (!decimal.TryParse(numberStrings[i], NumberStyles.AllowDecimalPoint,CultureInfo.InvariantCulture, out var number))
                {
                    WriteLine($"Incorrect input in numbers {numberStrings[i]}");
                    return;
                }

                sum += number;
            }
            
            WriteLine($"Sum of number's is  {sum:f4}");
            
            // Program Stop
            ReadLine();
        }
    }
}