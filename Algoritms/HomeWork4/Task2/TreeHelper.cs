using System.Collections.Generic;

namespace Task2
{
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(this ITree tree)
        {
            var buffer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            buffer.Enqueue(root);

            while (buffer.Count != 0)
            {
                var element = buffer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.Left is not null)
                {
                    var left = new NodeInfo(depth, element.Node.Left);
                    buffer.Enqueue(left);
                }

                if (element.Node.Right is null) continue;
                
                var right = new NodeInfo(depth, element.Node.Right);
                buffer.Enqueue(right);
            }

            return returnArray.ToArray();
        }
        
        public static (int depth,int nodeValue)[] GetTreeInLineForTest(this ITree tree)
        {
            var buffer = new Queue<NodeInfo>();
            var returnArray = new List<(int,int)>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            buffer.Enqueue(root);

            while (buffer.Count != 0)
            {
                var element = buffer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.Left is not null)
                {
                    var left = new NodeInfo(depth, element.Node.Left);
                    buffer.Enqueue(left);
                }

                if (element.Node.Right is null) continue;
                
                var right = new NodeInfo(depth, element.Node.Right);
                buffer.Enqueue(right);
            }

            return returnArray.ToArray();
        }
    }
}