using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] GenerateArray(int length,int maxNumber)
            {
                var r = new Random();
                List<int> result = new();
                for (var i = 0; result.Count < length; i++)
                {
                    result.Add(r.Next(maxNumber));
                }
                return result.ToArray(); 
            }
            
            BinaryTree tree = new(true,GenerateArray(50,1000));
            Console.WriteLine(tree.AsString());
        }

        
    }
}