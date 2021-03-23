using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = BuildDemoGraph();
            Logger logger = new();
            
            graph.TraverseDFS(logger);
            Console.WriteLine("Check All visited");
            foreach (var node in graph.Nodes)
                Console.WriteLine($"{node.Value} {node.IsVisited}");
            
            Console.WriteLine("\n\n");
            
            graph = BuildDemoGraph();
            graph.TraverseBFS(logger);
            Console.WriteLine("Check All visited");
            foreach (var node in graph.Nodes)
                Console.WriteLine($"{node.Value} {node.IsVisited}");
        }

        static Graph BuildDemoGraph()
        {
            Graph graph = new();
            
            var node1 = graph.AddNode(3);
            var node3 = graph.AddNode(5);
            var node4 = graph.AddNode(4);
            var node5 = graph.AddNode(2);
            var node6 = graph.AddNode(8);
            var node7 = graph.AddNode(7);
            
            graph.ConnectNodes(node1,node3,false,3);
            graph.ConnectNodes(node4,node3,true,2);
            graph.ConnectNodes(node1,node5,false,7);
            graph.ConnectNodes(node5,node4,false,5);
            graph.ConnectNodes(node7,node3,false,9);
            graph.ConnectNodes(node6,node3,true,4);
            graph.ConnectNodes(node1,node6,false,1);
            graph.ConnectNodes(node6,node4,false,2);
            
            return graph;
        }
    }
}