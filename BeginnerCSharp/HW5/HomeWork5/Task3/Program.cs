using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Console;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string file = "test.bin";

            WriteLine("Input a case of number's in range [0..255] separating with whitespace");
            var input = ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (input is null)
            {
                WriteLine("incorrect input");
                return;
            }

            var array = new byte[input.Length];
            for (var i = 0; i < array.Length; i++)
            {
                if (!byte.TryParse(input[i], out var number))
                {
                    WriteLine($"Incorrect number {input[i]}");
                    return;
                }

                array[i] = number;
            }

            using (var bw = new BinaryWriter(File.OpenWrite(file)))
            {
                bw.Write(array);
                bw.Flush();
            }

            WriteLine("see what now in file {file}");

            WriteLine("i read it for you");
            byte[] newData;
            using (var br = new BinaryReader(File.OpenRead(file)))
            {
                newData = br.ReadBytes(array.Length);
            }

            for (var i = 0; i < newData.Length; i++)
            {
                Write(newData[i] + " ");
            }
        }
    }
}