using System;
using System.Globalization;
using static System.Console;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string incorrectMonthMessage = "Not correct month number";

            WriteLine("Please input number of the current month");
            var monthNumber = ReadLine().AsSpan();
            
            if (!int.TryParse(monthNumber, out var number))
            {
                WriteLine(incorrectMonthMessage);
                return;
            }

            if (number <= 0 || number > 12)
            {
                WriteLine(incorrectMonthMessage);
                return;
            }

            var date = new DateTime(2021, number, 1);
            
            WriteLine($"Current month name is {date.ToString("MMMM", CultureInfo.CurrentCulture)}");
        }
    }
}