using System;
using System.Collections.Generic;
using System.Linq;

namespace AppFor_Task1_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePrinter printer = new(new []
            {
                new CharConsoleColor('H',ConsoleColor.Cyan),
                new CharConsoleColor('l',ConsoleColor.Yellow),
                new CharConsoleColor('W',ConsoleColor.Red),
                new CharConsoleColor('d',ConsoleColor.Magenta)
            });
            
            printer.Print("Hello World!");
        }
    }

    public class ConsolePrinter
    {
        private readonly List<CharConsoleColor> _colors;
        private const ConsoleColor DefaultColor = ConsoleColor.White;
        public ConsolePrinter(IEnumerable<CharConsoleColor> colors) => _colors = colors.ToList();

        public void Print(string toPrint)
        {
            var length = toPrint.Length;
            for (var i = 0; i < length; i++)
            {
                var color = _colors.Find(c => c == toPrint[i]);
                if(color is null) Console.Write(toPrint[i]);
                else PrintWithColor(toPrint[i], color);
            } 
        }

        private static void PrintWithColor(char character, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ForegroundColor = DefaultColor;
        }
    }

    public class CharConsoleColor
    {
        public char Character { get; init; }
        public ConsoleColor Color { get; init; }

        public CharConsoleColor(char character, ConsoleColor color)
        {
            Character = character;
            Color = color;
        }
        
        public static implicit operator char(CharConsoleColor toParse) => toParse.Character;
        public static implicit operator ConsoleColor(CharConsoleColor toParse) => toParse.Color;
    }
}