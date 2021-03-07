using System;
using System.Collections.Generic;

namespace Task2
{
    public class BinaryTree : ITree
    {
        private TreeNode _root;
        private int _counter = 0;
        public int Length => _counter;
        public bool IgnoreExistValues { get; set; }
        public BinaryTree(){}

        public BinaryTree(int value)
        {
            _root = new(value);
            _counter++;
        }

        public BinaryTree(bool ignoreExistValues, params int[] values)
        {
            IgnoreExistValues = ignoreExistValues;
            for (var i = 0; i < values.Length; i++)
            {
                AddItem(values[i]);
                _counter++;
            }
        }
        



        #region Implementation of ITree

        /// <inheritdoc />
        public TreeNode GetRoot() => _root;

        /// <inheritdoc />
        public void AddItem(int value)
        {
            if (_root is null)
            {
                _root = new(value);
                _counter++;
                return;
            }
            
            var tmp = _root;
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
                    _counter++;
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
                    _counter++;
                    return;
                }

                if (value != tmp.Value) continue;
                if(IgnoreExistValues)break;
                throw new("There must be custom exception that value already in tree");
            }
        }

        /// <inheritdoc />
        public void RemoveItem(int value)
        {
            if (_root.Value == value)
            {
                if (_root.Right is null)
                {
                    var newRoot = _root.Left;
                    _root.Left = null;
                    _root = newRoot;
                    _counter--;
                    return;
                }
                else
                {
                    var newRoot = Remove(_root);
                    newRoot.Left = _root.Left;
                    newRoot.Right ??= _root.Right;
                    _root.Left = _root.Right = null;
                    _root = newRoot;
                    _counter--;
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
                _counter--;
                return;
            }
            if (parent.Right?.Value == value)
            {
                var toReplace = Remove(toRemove);
                toReplace.Left = toRemove.Left;
                parent.Right = toReplace;
                _counter--;
            }
        }


        private static TreeNode Remove(TreeNode node)
        {
            if (node.Right is null) return node.Left;
            var prev = node;
            var current = node.Right;
            while (true)
            {
                var toLeave = 0;
                if (current!.Left is not null)
                {
                    toLeave++;
                }

                if (current.Right is not null)
                {
                    toLeave++;
                }
                if(toLeave == 0) break;
                prev = current;
                current = current.Left ?? current.Right;
            }

            if(prev.Left?.Value == current.Value) prev.Left = null;
            if (prev.Right?.Value == current.Value) prev.Right = null;
            return current;
        }

        private void GetNodeWithParent(int value, out TreeNode parent, out TreeNode searched)
        {
            parent = searched = null;
            if (_root is null) return;
            if (_root.Value == value)
            {
                searched = _root;
                return;
            }

            searched = parent = _root;
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
        public void PrintTree() => Console.WriteLine(this.AsString());

        #endregion
    }
}