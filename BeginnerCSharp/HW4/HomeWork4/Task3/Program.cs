using System;
using static System.Console;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("input your current month number");
            var input = ReadLine().AsSpan();

            if (!int.TryParse(input, out var monthNumber))
            {
                WriteLine("Incorrect input");
                return;
            }

            if (monthNumber < 1 || monthNumber > 12)
            {
                WriteLine("Incorrect input, needed number must be in [1..12]");
                return;
            }

            var season = monthNumber switch
                         {
                             12 or <= 2 => YearSeason.Winter,
                             <=5        => YearSeason.Spring,
                             <=7        => YearSeason.Summer,
                             _          => YearSeason.Autumn
                         };
            WriteLine($"Current season is {season}");
            
        }

        private enum YearSeason
        {
            Winter,Spring,Summer,Autumn
        }
    }
}