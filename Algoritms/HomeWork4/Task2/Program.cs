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

        public class AVLTree : ITree
        {
            private TreeNode root;
            
            #region Implementation of ITree

            /// <inheritdoc />
            public TreeNode GetRoot() => root;

            /// <inheritdoc />
            public void AddItem(int value)
            {
            }

            /// <inheritdoc />
            public void RemoveItem(int value)
            {
            }

            /// <inheritdoc />
            public TreeNode GetNodeByValue(int value)
            {
                GetNodeWithParent(value,out _, out var result);
                return result;
            }


            /// <inheritdoc />
            public void PrintTree() => Console.WriteLine(this.AsString());

            #endregion


            private void LowRotate(Side side, TreeNode node)
            {
                TreeNode newRoot;
                
                if (side == Side.Left)
                {
                    newRoot = node.Right;
                    node.Right = newRoot.Left;
                    newRoot.Left = node;
                }
                else
                {
                    newRoot = node.Left;
                    node.Left = newRoot.Right;
                    newRoot.Right = node;
                }

                CalcHeight(node);
                CalcHeight(newRoot);
            }

            private void BigRotate(Side side, TreeNode node)
            {
                if (side == Side.Left)
                {
                    LowRotate(Side.Right,node.Right);
                    LowRotate(Side.Left,node);
                }
                else
                {
                    LowRotate(Side.Left,node.Left);
                    LowRotate(Side.Right,node);
                }
            }

            private void CalcHeight(TreeNode node)
            {
                // ???
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

            private enum Side{Left,Right}
        }
    }
}