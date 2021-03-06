using System;
using System.Collections.Generic;

namespace SearchingInTree
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        // ReSharper disable once InconsistentNaming
        private void TraverseDFS(TreeNode root, int searchValue)
        {
            Stack<TreeNode> stack = new();
            stack.Push(root);
            
            while (true)
            {
                var node = stack.Pop();
                Console.WriteLine(node.Value);
                if (node.Right is not null) stack.Push(node.Right);
                if (node.Left is not null) stack.Push(node.Left);
                if (stack.Count > 0) continue;
                break;
            }
        }

        // ReSharper disable once InconsistentNaming
        private void TraverseBFS(TreeNode root, int searchValue)
        {
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            
            while (true)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node.Value);
                if (node.Right is not null) queue.Enqueue(node.Right);
                if (node.Left is not null) queue.Enqueue(node.Left);
                if (queue.Count > 0) continue;
                break;
            }   
        }
    }
}