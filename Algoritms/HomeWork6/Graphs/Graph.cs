using System.Collections.Generic;

namespace Graphs
{
    public class Graph
    {
        public readonly List<Node> Nodes = new();

        public Node AddNode(int value)
        {
            var node = new Node(value);
            Nodes.Add(node);
            return node;
        }

        public void ConnectNodes(Node left, Node right, bool isTwoSideConnection, int weight)
        {
            if (isTwoSideConnection)
            {
                left.AddConnection(new(weight, right, true));
                right.AddConnection(new(weight, left, true));
                return;
            }
            
            left.AddConnection(new (weight,right));
        }
    }
}