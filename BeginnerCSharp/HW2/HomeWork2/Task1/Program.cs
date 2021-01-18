using System;
using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Suggestion: there may be loop to ask user input correct value, and not drop program, and other user interface improvements
            const string inputMessage = "Please input {0} Temperature of the day";
            const string notCorrectMessage = "{0} temperature not correct";
            
            WriteLine(inputMessage,"minimum");
            var minimalTemperature = ReadLine().AsSpan();
            if (!float.TryParse(minimalTemperature, out var min))
            {
                WriteLine(notCorrectMessage,"Minimum");
                return;
            }
            
            WriteLine(inputMessage, "maximum");
            var maximumTemperature = ReadLine().AsSpan();
            if (!float.TryParse(maximumTemperature, out var max))
            {
                WriteLine(notCorrectMessage,"Maximum");
                return;
            }

            var averageTemperature = (min + max) / 2;
            WriteLine($"The average daily temperature is {averageTemperature}");
        }
    }
}