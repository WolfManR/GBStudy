using System;
using System.IO;
using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Input file path to save data");
            
            var path = ReadLine();
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                WriteLine("Incorrect Path");
                return;
            }

            if (!path.EndsWith(".txt")) path += ".txt";
            using var fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate);
            using var sw = new StreamWriter(fs);
            
            
            WriteLine("Input data to save in text file, press Esc to stop");
            sw.AutoFlush = true;
            while (true)
            {
                var inputKey = ReadKey();
                
                if(inputKey.Key == ConsoleKey.Escape)
                    break;
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    sw.Write("\n");
                    WriteLine();
                }
                else sw.Write(inputKey.KeyChar);
            }


            // Program Stop
            WriteLine("\nWork Done, cya");
        }
    }
}