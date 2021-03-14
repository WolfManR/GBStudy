using System.Collections.Generic;

namespace SearchingInTree
{
    public static class TraverseTreeExtensions
    {
        // ReSharper disable once InconsistentNaming
        public static int? TraverseDFS(this BinaryTree tree, int searchValue, Logger logger)
        {
            Stack<TreeNode> stack = new();
            logger.LogInfo("Creation of Stack");
            
            var root = tree.GetRoot();
            logger.LogInfo("Get Root from tree");
            
            stack.Push(root);
            logger.LogStep("Place root of tree in stack", root.Value);
            
            while (true)
            {
                var node = stack.Pop();
                logger.LogStep(Behavior.Pop, node.Value);
                
                if (node.Value == searchValue)
                {
                    logger.LogInfo("Found needed value");
                    return node.Value;
                }
                logger.LogInfo("Value not needed");

                if (node.Right is not null)
                {
                    stack.Push(node.Right);
                    logger.LogStep(Behavior.Push, node.Right.Value, Side.Right);
                }

                if (node.Left is not null)
                {
                    stack.Push(node.Left);
                    logger.LogStep(Behavior.Push, node.Left.Value, Side.Left);
                }
                
                if (stack.Count > 0) 
                    continue;
                break;
            }

            logger.LogInfo($"Failure on search value: {searchValue}");
            return null;
        }

        // ReSharper disable once InconsistentNaming
        public static int? TraverseBFS(this BinaryTree tree, int searchValue, Logger logger)
        {
            Queue<TreeNode> queue = new();
            logger.LogInfo("Creation of Queue");

            var root = tree.GetRoot();
            logger.LogInfo("Get Root from tree");
            
            queue.Enqueue(root);
            logger.LogStep("Place root of tree in queue", root.Value);
            
            while (true)
            {
                var node = queue.Dequeue();
                logger.LogStep(Behavior.Dequeue, node.Value);

                if (node.Value == searchValue)
                {
                    logger.LogInfo("Found needed value");
                    return node.Value;
                }
                logger.LogInfo("Value not needed");
                
                if (node.Right is not null)
                {
                    queue.Enqueue(node.Right);
                    logger.LogStep(Behavior.Enqueue, node.Right.Value, Side.Right);
                }

                if (node.Left is not null)
                {
                    queue.Enqueue(node.Left);
                    logger.LogStep(Behavior.Enqueue, node.Left.Value, Side.Left);
                }
                if (queue.Count > 0) 
                    continue;
                break;
            }   
            logger.LogInfo($"Failure on search value: {searchValue}");
            return null;
        }
    }
}