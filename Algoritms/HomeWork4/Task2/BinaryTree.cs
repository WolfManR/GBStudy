using System;
using System.Collections.Generic;

namespace Task2
{
    public class BinaryTree : ITree
    {
        private TreeNode root;
        private int counter = 0;
        public BinaryTree(){}

        public BinaryTree(int value)
        {
            root = new(value);
            counter++;
        }

        public BinaryTree(params int[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                AddItem(values[i]);
                counter++;
            }
        }
        



        #region Implementation of ITree

        /// <inheritdoc />
        public TreeNode GetRoot() => root;

        /// <inheritdoc />
        public void AddItem(int value)
        {
            if (root is null)
            {
                root = new(value);
                return;
            }
            
            var tmp = root;
            while (true)
            {
                if (value > tmp.Value)
                {
                    if (tmp.Right is not null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }

                    tmp.Right = new(value);
                    return;
                }

                if (value < tmp.Value)
                {
                    if (tmp.Left is not null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }

                    tmp.Left = new(value);
                    return;
                }
                
                if (value == tmp.Value) throw new("There must be custom exception that value already in tree");
            }
        }

        /// <inheritdoc />
        public void RemoveItem(int value)
        {
            if (root.Value == value)
            {
                if (root.Right is null)
                {
                    var newRoot = root.Left;
                    root.Left = null;
                    root = newRoot;
                    return;
                }
                else
                {
                    var newRoot = Remove(root);
                    newRoot.Left = root.Left;
                    if (newRoot.Right is null) newRoot.Right = root.Right;
                    root.Left = root.Right = null;
                    root = newRoot;
                    return;
                }
                
            }

            GetNodeWithParent(value, out var parent, out var toRemove);
            if (toRemove is null) return;
            if (parent.Left?.Value == value)
            {
                var toReplace = Remove(toRemove);
                toReplace.Left = toRemove.Left;
                parent.Left = toReplace;
                return;
            }
            if (parent.Right?.Value == value)
            {
                var toReplace = Remove(toRemove);
                toReplace.Left = toRemove.Left;
                parent.Right = toReplace;
            }
        }


        private static TreeNode Remove(TreeNode node)
        {
            if (node.Right is null) return node.Left;
            var prev = node;
            var current = node.Right;
            while (current.Left is not null)
            {
                prev = current;
                current = current.Left;
            }

            if(prev.Left?.Value == current.Value) prev.Left = null;
            return current;
        }

        private void GetNodeWithParent(int value, out TreeNode parent, out TreeNode searched)
        {
            parent = searched = null;
            if (root is null) return;
            if (root.Value == value)
            {
                searched = root;
                return;
            }

            searched = parent = root;
            while (true)
            {
                if (value > searched.Value)
                {
                    if (searched.Right is null)
                    {
                        parent = searched = null;
                        return;
                    }
                    parent = searched;
                    searched = searched.Right;
                    continue;
                }

                if (value < searched.Value)
                {
                    if (searched.Left is null)
                    {
                        parent = searched = null;
                        return;
                    }
                    parent = searched;
                    searched = searched.Left;
                    continue;
                }

                if (searched.Value == value) return;
            }
        }

        /// <inheritdoc />
        public TreeNode GetNodeByValue(int value)
        {
            GetNodeWithParent(value,out _, out var result);
            return result;
        }

        /// <inheritdoc />
        public void PrintTree()
        {
            // Stack<TreeNode> stack = new();
            // stack.Push(root);
            // TraverseDFS(stack);
            Console.WriteLine();
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            TraverseBFS(queue);
        }

        private void TraverseDFS(Stack<TreeNode> stack)
        {
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

        private void TraverseBFS(Queue<TreeNode> queue)
        {
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
        
        
        #endregion
    }
}