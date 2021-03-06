using System;

namespace SearchingInTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree(16, 8, 9, 2, 1, 4, 24, 26, 19, 21, 20, 23);
            
            var logger = new Logger(delayInSeconds: 0);
            
            logger.LogInfo($"Tree:\n{tree.AsString()}");

            Console.WriteLine();
            
            var dfs = tree.TraverseDFS(19,logger);
            logger.LogInfo($"TraverseDFS found value is {dfs}");
            
            Console.WriteLine();
            
            var bfs = tree.TraverseBFS(19,logger);
            logger.LogInfo($"TraverseDFS found value is {bfs}");

            // Program Stop
            Console.WriteLine("Work Done");
            Console.ReadLine();
        }
    }
}