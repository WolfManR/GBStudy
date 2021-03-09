using System;
using System.Collections.Generic;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; }

        public Node(int value, List<Edge> edges = null)
        {
            Value = value;
            Edges = edges ?? new List<Edge>();
        }
    }

    public class Edge
    {
        public int Weight { get; set; }
        public Node Node { get; set; }
    }


    public class Graph
    {
        private List<Node> Nodes;
        
        public Graph(int value) => AddNode(value);

        public void AddNode(int value)
        {
            Nodes.Add(new(value));
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void TraverseDFS()
        {
            
        }
    }
}