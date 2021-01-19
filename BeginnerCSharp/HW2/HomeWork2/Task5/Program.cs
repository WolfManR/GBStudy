using System;
using System.Globalization;
using static System.Console;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string incorrectMonthMessage = "Not correct month number";

            WriteLine("Please input number of the current month");
            var monthNumberInput = ReadLine().AsSpan();
            
            // validation of month number
            if (!int.TryParse(monthNumberInput, out var monthNumber))
            {
                WriteLine(incorrectMonthMessage);
                return;
            }

            if (monthNumber <= 0 || monthNumber > 12)
            {
                WriteLine(incorrectMonthMessage);
                return;
            }
            
            
            const string inputMessage = "Please input {0} Temperature of the day";
            const string notCorrectMessage = "{0} temperature not correct";
            
            // validation of minimum temperature
            WriteLine(inputMessage,"minimum");
            var minimalTemperature = ReadLine().AsSpan();
            if (!float.TryParse(minimalTemperature, out var min))
            {
                WriteLine(notCorrectMessage,"Minimum");
                return;
            }
            
            // validation of maximum temperature
            WriteLine(inputMessage, "maximum");
            var maximumTemperature = ReadLine().AsSpan();
            if (!float.TryParse(maximumTemperature, out var max))
            {
                WriteLine(notCorrectMessage,"Maximum");
                return;
            }

            var averageTemperature = (min + max) / 2;
            
            
            if((monthNumber == 12 || monthNumber <= 2) && averageTemperature > 0)
                WriteLine("It's rainy winter today");
            
            WriteLine($"The average daily temperature is {averageTemperature}");
            var date = new DateTime(2021, monthNumber, 1);
            WriteLine($"Current month name is {date.ToString("MMMM", CultureInfo.CurrentCulture)}");
                
                
            // Program stop
            ReadLine();
        }

        
    }
}