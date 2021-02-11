using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            using var sw = File.AppendText("startup.txt");
            var time = DateTime.Now.ToString("HH:mm:ss tt");
            sw.WriteLine(time);
            Console.WriteLine($"I add to startup.txt new time, it's {time}, go check");
        }
    }
}