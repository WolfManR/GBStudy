using static System.Console;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte size = 5;
            var array = new int[size, size];

            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    array[i, j] = i + j;

            for (int i = 0,j = 0; i < size; i++, j++)
                Write(array[i,j]);
            
            // Program stop
            WriteLine();
            ReadLine();
        }
    }
}