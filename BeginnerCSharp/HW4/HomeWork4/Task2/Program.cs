using System;
using System.Collections.Generic;
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

            if (!TryParseInputToDecimals(input, out var result, out var incorrectNumber))
            {
                WriteLine($"Incorrect input in number {incorrectNumber}");
                return;
            }
            
            decimal sum = 0;
            for (var i = 0; i < result.Length; i++)
                sum += result[i];
            
            WriteLine($"Sum of number's is  {sum:f4}");
            
            // Program Stop
            ReadLine();
        }

        private const NumberStyles Style = NumberStyles.AllowDecimalPoint;
        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
        
        private static bool TryParseInputToDecimals(string input, out decimal[] result, out string incorrectNumber)
        {
            incorrectNumber = "";
            result = Array.Empty<decimal>();
            var temp = new List<decimal>();
            
            var numberStrings = input.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < numberStrings.Length; i++)
            {
                if (!decimal.TryParse(numberStrings[i], Style, Culture, out var number))
                {
                    incorrectNumber = numberStrings[i];
                    return false;
                }
                temp.Add(number);
            }

            result = temp.ToArray();
            return true;
        }
    }
}