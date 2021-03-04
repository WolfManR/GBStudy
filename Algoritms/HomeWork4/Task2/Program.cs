using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new(10, 8, 9, 2, 1, 4, 13, 12, 15);
            Console.WriteLine(tree.AsString());
        }

        
    }
}