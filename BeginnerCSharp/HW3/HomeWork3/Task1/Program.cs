using System;
using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte size = 5;
            var array = new int[size, size];

            // Fill array
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    array[i, j] = i + j;
            
            // Print array
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                    Write(array[i, j] + " ");
                WriteLine();
            }
            
            WriteLine($"Input Pad from central diagonal, from [-{size-1}..0..{size-1}]");
            var input = ReadLine().AsSpan();
            
            if (!int.TryParse(input, out var number))
            {
                WriteLine("incorrect input");
                return;
            }

            if (number <= -size || number >= size)
            {
                WriteLine("Incorrect number");
                return;
            }

            int normalizedNumber = number < 0 ? Math.Abs(number) : number;
            var times = size - Math.Abs(number);
            //diagonal
            for (int i = 0,j = 0; i < times; i++, j++)
            {
                var output = number switch
                             {
                                 0  => array[i, j],
                                 <0 => array[i, j + normalizedNumber],
                                 _  => array[i + normalizedNumber, j]
                             };
                Write(output + " ");
            }
            
            // Program stop
            WriteLine();
            ReadLine();
        }
    }
}