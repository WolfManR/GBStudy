using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}

namespace Task1.ListRealization
{
    public record Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
        
        // todo: to remake to class, add IEqualityComparer support 
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class MyLinkedList : ILinkedList
    {
        private int counter = 0;
        private Node StartPoint;
        private Node LastNode;
        public int Length => counter;

        public MyLinkedList() { }
        public MyLinkedList(int value) => StartPoint = LastNode = new() {Value = value};
        public MyLinkedList(params int[] values)
        {
            StartPoint = LastNode = new() {Value = values[0]};
            counter++;
            for (;counter < values.Length; counter++)
            {
                var next = new Node() {Value = values[counter], PrevNode = LastNode};
                LastNode.NextNode = next;
                LastNode = next;
            }
        }
        
        private Node GetNodeOnIndex(int index)
        {
            if (index < 0 || index > counter) return null;
            
            Node needed;
            
            if(counter/2 >= index)
            {
                needed = StartPoint;
                for (var i = 0; i <= index; i++)
                {
                    needed = needed.NextNode;
                }
            }
            else
            {
                needed = LastNode;
                for (var i = counter - 1; i >= index; i--)
                {
                    needed = needed.PrevNode;
                }
            }

            return needed;
        }

        private bool IsNodeExistInCurrentList(Node node) => GetEnumerator().Any(current => current == node);

        public int this[int index]
        {
            get => GetNodeOnIndex(index)?.Value ?? throw new IndexOutOfRangeException();
            set
            {
                var needed = GetNodeOnIndex(index) ?? throw new IndexOutOfRangeException();
                if (needed.Value == value) return;
                needed.Value = value;
            }
        }

        public IEnumerable<Node> GetEnumerator()
        {
            var current = StartPoint;
            do
            {
                yield return current;
                current = current.NextNode;
            } while (current.NextNode is not null);
        }
        

        #region Implementation of ILinkedList

        /// <inheritdoc />
        public int GetCount() => counter;

        /// <inheritdoc />
        public void AddNode(int value)
        {
            if (StartPoint == null)
            {
                StartPoint = LastNode = new() {Value = value};
            }
            else
            {
                var newOne = new Node() {Value = value, PrevNode = LastNode};
                LastNode.NextNode = newOne;
                LastNode = newOne;
            }
            
            counter++;
        }

        /// <inheritdoc />
        public void AddNodeAfter(Node node, int value)
        {
            if (!IsNodeExistInCurrentList(node))
                throw new("There must be custom exception about not existing node in current collection");
            
            var next = node.NextNode;
            var newOne = new Node() {Value = value, NextNode = next, PrevNode = node};
            node.NextNode = newOne;
            if(next is not null) next.PrevNode = newOne;
            counter++;
        }

        /// <inheritdoc />
        public void RemoveNode(int index)
        {
            if (index == 0)
            {
                if (StartPoint.NextNode is { } node)
                {
                    StartPoint = node;
                    node.PrevNode = null;
                }
                else StartPoint = LastNode = null;
            }
            else
            {
                var toRemove = GetNodeOnIndex(index);

                if(toRemove.NextNode is not null) 
                    toRemove.NextNode.PrevNode = toRemove.PrevNode;
                toRemove.PrevNode.NextNode = toRemove.NextNode;
                toRemove.NextNode = toRemove.PrevNode = null;
            }
            
            counter--;
        }

        /// <inheritdoc />
        public void RemoveNode(Node node)
        {
            if (!IsNodeExistInCurrentList(node))
                throw new("There must be custom exception about not existing node in current collection");
            if (StartPoint == node)
            {
                if (StartPoint == LastNode)
                {
                    StartPoint = LastNode = null;
                }
                else
                {
                    StartPoint = node.NextNode;
                    node.NextNode = null;
                }
            }
            else
            {
                if(node.NextNode is not null)
                    node.NextNode.PrevNode = node.PrevNode;
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode = node.PrevNode = null;
            }
            
            counter--;
        }

        /// <inheritdoc />
        public Node FindNode(int searchValue)
        {
            var current = StartPoint;
            do
            {
                if(current.Value == searchValue) return current;
            } while (current.NextNode is not null);

            return null;
        }

        #endregion
    }
}