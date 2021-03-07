using System;
using System.Threading;

namespace SearchingInTree
{
    public class Logger
    {
        private readonly int _delayInSeconds;
        private const int Second = 1000;
        
        public Logger(int delayInSeconds)
        {
            if (delayInSeconds < 0) throw new ArgumentException("delay can't be lower 0");
            _delayInSeconds = delayInSeconds;
        }
        

        public void LogInfo(string info)
        {
            Header("info", ConsoleColor.Green);
            Console.WriteLine(info);
            
            Thread.Sleep(_delayInSeconds * Second);
        }

        public void LogStep(string msg, int? value = null)
        {
            Header("step", ConsoleColor.Red);
            Console.Write(msg);
            Console.WriteLine(value is null ? string.Empty : $" with value {value}");
            
            Thread.Sleep(_delayInSeconds * Second);
        }
        
        public void LogStep(Behavior behavior, int value, Side? side = null)
        {
            Header("step", ConsoleColor.Blue);
            Header($"{behavior}", behavior switch
                                  {
                                      Behavior.Push    => ConsoleColor.Magenta,
                                      Behavior.Pop     => ConsoleColor.DarkCyan,
                                      Behavior.Enqueue => ConsoleColor.Magenta,
                                      Behavior.Dequeue => ConsoleColor.DarkCyan
                                  });
            if(side is not null)
                Header($"{side}", side switch
                                  {
                                      Side.Left  => ConsoleColor.Yellow,
                                      Side.Right => ConsoleColor.Cyan
                                  });
            Console.WriteLine($" with value {value}");
            
            Thread.Sleep(_delayInSeconds * Second);
        }
        
        
        private void Header(string header, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"[{header.ToUpper()}]");
            Separator();
        }

        private void Separator()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" - ");
        }
    }
}