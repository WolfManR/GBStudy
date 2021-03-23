using System.Collections.Generic;

namespace Graphs
{
    public static class TraverseExtensions
    {
        public static void TraverseDFS(this Graph graph, Logger logger)
        {
            var nodes = graph.Nodes;
            logger.LogInfo("DFS initialized");
            
            foreach (var node in nodes)
            {
                logger.LogStep(Step.OuterCheck, node.Value, node.IsVisited);
                if (node.IsVisited) continue;
                
                TraverseRecursion(node,logger);
                logger.LogStep(Way.Out, "Not have edges with possible way to not visited nodes");
            }
            
            logger.LogInfo("DFS work done");
        }

        private static void TraverseRecursion(Node node, Logger logger)
        {
            logger.LogStep(Step.Check, node.Value, node.IsVisited);
            if (node.IsVisited)
            {
                logger.LogStep(Way.Out);
                return;
            }
            node.IsVisited = true;

            if (node.Edges.Count == 0)
            {
                logger.LogStep(Way.Out, "Not have edges");
                return;
            }
            foreach (var edge in node.Edges)
            {
                logger.LogStep(Step.Check, edge);
                if (edge.Node.IsVisited) continue;
                
                logger.LogStep(Way.In);
                TraverseRecursion(edge.Node,logger);
            }
            logger.LogStep(Way.Out);
        }
        
        public static void TraverseBFS(this Graph graph, Logger logger)
        {
            var nodes = graph.Nodes;
            Queue<Node> front = new();
            
            logger.LogInfo("BFS initialized");
            
            foreach (var currentNode in nodes)
            {
                logger.LogStep(Step.OuterCheck, currentNode.Value, currentNode.IsVisited);
                
                if (currentNode.IsVisited)
                {
                    logger.LogStep(Way.Out);
                    continue;
                }
                
                front.Enqueue(currentNode);
                logger.LogStep(Behavior.Enqueue,currentNode.Value);
                
                while (true)
                {
                    if (front.Count == 0)
                    {
                        logger.LogStep(Way.Out, "Not have edges with possible way to not visited nodes");
                        break;
                    }
                    
                    var node = front.Dequeue();
                    logger.LogStep(Behavior.Dequeue,node.Value);
                    
                    logger.LogStep(Step.Check, node.Value, node.IsVisited);
                    
                    if (!node.IsVisited)
                    {
                        logger.LogStep(Way.In);
                        node.IsVisited = true;
                    }
                    else
                    {
                        logger.LogStep(Way.Out);
                        continue;
                    }
                    
                    if (node.Edges.Count <= 0)
                    {
                        logger.LogStep(Way.Out, "Not have edges");
                        continue;
                    }
                    
                    foreach (var edge in node.Edges)
                    {
                        logger.LogStep(Step.Check, edge);
                        if(edge.Node.IsVisited) continue;
                        
                        front.Enqueue(edge.Node);
                        logger.LogStep(Behavior.Enqueue,edge.Node.Value);
                    }
                    
                    logger.LogStep(Way.Out);
                }
            }
        }
    }
}