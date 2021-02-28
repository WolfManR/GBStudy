using System;
using System.Collections.Generic;
using System.Linq;
using Task1.ListRealization;
using Xunit;

namespace Task1Tests
{
    public class MyLinkedListTests
    {
        [Fact]
        public void Correctly_LengthOfArray_Updates_OnInitializingCollection()
        {
            MyLinkedList sub = new();
            Assert.Equal(0,sub.Length);

            sub = new(1);
            Assert.Equal(1,sub.Length);

            sub = new(1, 2, 4, 5, 6);
            Assert.Equal(5,sub.Length);
        }
        
        [Theory]
        [InlineData(3,new[]{2,3})]
        [InlineData(2,new[]{2})]
        [InlineData(8,new[]{2,3,4,1,5,7,8})]
        public void Successfully_FindNode(int expected, int[] toAdd)
        {
            MyLinkedList sub = new(toAdd);
            var result = sub.FindNode(expected);
            Assert.Equal(expected,result.Value);
        }
        
        [Fact]
        public void Failure_FindItem_WhenCollectionNotHaveItems()
        {
            MyLinkedList sub = new();
            
            var toRemove = sub.FindNode(1);
            Assert.True(toRemove is null);
        }

        [Theory]
        [InlineData(3,new[]{2,3})]
        [InlineData(2,new[]{2})]
        [InlineData(8,new[]{2,3,4,1,5,7,8})]
        public void Successfully_NewItemAddedToEnd(int expected, int[] toAdd)
        {
            MyLinkedList sub = new();
            foreach (var number in toAdd)
                sub.AddNode(number);
            var last = sub[^1];
            Assert.Equal(expected,last);
        }
        
        [Fact]
        public void Successfully_NewItemAddedAfterNode()
        {
            MyLinkedList sub = new(1, 2, 3);
            var node = sub.FindNode(2);
            sub.AddNodeAfter(node,4);
            var toCheck = sub.FindNode(4);
            Assert.Equal(2,toCheck.PrevNode.Value);
            Assert.Equal(3,toCheck.NextNode.Value);
            Assert.Equal(4,toCheck.Value);
            Assert.Equal(4,sub.Length);
        }

        [Fact]
        public void Failure_NewItemAddedAfterNodeThatNotExistInCollection()
        {
            Assert.Throws<Exception>(() =>
            {
                var failNode = new Node() {Value = 2};
                MyLinkedList sub = new(1, 2, 3);
                sub.AddNodeAfter(failNode,4);
            });
        }
        
        
        [Fact]
        public void Successfully_RemoveLastItem_OnIndex_WhenCollectionHaveMultipleItems()
        {
            MyLinkedList sub = new(1, 2, 3);
            sub.RemoveNode(2);
            Assert.True(sub.FindNode(3) is null);
            Assert.Equal(2,sub.Length);
        }

        [Fact]
        public void Successfully_RemoveFirstItem_OnIndex_WhenCollectionHaveMultipleItems()
        {
            MyLinkedList sub = new(1, 2, 3);
            sub.RemoveNode(0);
            Assert.True(sub.FindNode(1) is null);
            Assert.True(sub.FindNode(2).PrevNode is null);
            Assert.Equal(2,sub.Length);
        }
        
        [Fact]
        public void Successfully_RemoveCenterItem_OnIndex_WhenCollectionHaveMultipleItems()
        {
            MyLinkedList sub = new(1, 2, 3);
            sub.RemoveNode(1);
            Assert.True(sub.FindNode(2) is null);
            Assert.Equal(2,sub.Length);

            var firstItem = sub.FindNode(1);
            var lastItem = sub.FindNode(3);
            Assert.True(firstItem.NextNode == lastItem && lastItem.PrevNode == firstItem);
        }
        
        [Fact]
        public void Successfully_RemoveLastItem_OnIndex_WhenCollectionHaveOneItem()
        {
            MyLinkedList sub = new(1);
            sub.RemoveNode(sub.Length - 1);
            Assert.True(sub.FindNode(1) is null);
            Assert.Equal(0,sub.Length);
        }

        [Fact]
        public void Successfully_RemoveFirstItem_OnIndex_WhenCollectionHaveOneItem()
        {
            MyLinkedList sub = new(1);
            sub.RemoveNode(0);
            Assert.True(sub.FindNode(1) is null);
            Assert.Equal(0,sub.Length);
        }
        
        [Fact]
        public void Failure_RemoveLastItem_OnIndex_WhenCollectionNotHaveItems()
        {
            Assert.Throws<Exception>(() =>
            {
                MyLinkedList sub = new();
                sub.RemoveNode(sub.Length - 1);
            });
        }

        [Fact]
        public void Failure_RemoveFirstItem_OnIndex_WhenCollectionNotHaveItems()
        {
            Assert.Throws<Exception>(() =>
            {
                MyLinkedList sub = new();
                sub.RemoveNode(0);
            });
        }
        
        
        
        
        
        [Fact]
        public void Successfully_RemoveLastItem_OnNode_WhenCollectionHaveMultipleItems()
        {
            MyLinkedList sub = new(1, 2, 3);
            
            var toRemove = sub.FindNode(3);
            sub.RemoveNode(toRemove);
            Assert.True(toRemove.NextNode is null);
            Assert.True(toRemove.PrevNode is null);
            
            Assert.True(sub.FindNode(3) is null);
            Assert.True(sub.FindNode(3) is null);
            Assert.Equal(2,sub.Length);
        }

        [Fact]
        public void Successfully_RemoveFirstItem_OnNode_WhenCollectionHaveMultipleItems()
        {
            MyLinkedList sub = new(1, 2, 3);
            
            var toRemove = sub.FindNode(1);
            sub.RemoveNode(toRemove);
            Assert.True(toRemove.NextNode is null);
            Assert.True(toRemove.PrevNode is null);
            
            Assert.True(sub.FindNode(1) is null);
            Assert.True(sub.FindNode(2).PrevNode is null);
            Assert.Equal(2,sub.Length);
        }
        
        [Fact]
        public void Successfully_RemoveCenterItem_OnNode_WhenCollectionHaveMultipleItems()
        {
            MyLinkedList sub = new(1, 2, 3);
            
            var toRemove = sub.FindNode(2);
            sub.RemoveNode(toRemove);
            Assert.True(toRemove.NextNode is null);
            Assert.True(toRemove.PrevNode is null);
            
            Assert.True(sub.FindNode(2) is null);
            Assert.Equal(2,sub.Length);

            var firstItem = sub.FindNode(1);
            var lastItem = sub.FindNode(3);
            Assert.True(firstItem.NextNode == lastItem && lastItem.PrevNode == firstItem);
        }
        
        [Fact]
        public void Successfully_RemoveLastItem_OnNode_WhenCollectionHaveOneItem()
        {
            MyLinkedList sub = new(1);
            
            var toRemove = sub.FindNode(1);
            sub.RemoveNode(toRemove);
            Assert.True(toRemove.NextNode is null);
            Assert.True(toRemove.PrevNode is null);
            
            Assert.True(sub.FindNode(1) is null);
            Assert.Equal(0,sub.Length);
        }

        [Fact]
        public void Successfully_RemoveFirstItem_OnNode_WhenCollectionHaveOneItem()
        {
            MyLinkedList sub = new(1);
            
            var toRemove = sub.FindNode(1);
            sub.RemoveNode(toRemove);
            Assert.True(toRemove.NextNode is null);
            Assert.True(toRemove.PrevNode is null);
            
            Assert.True(sub.FindNode(1) is null);
            Assert.Equal(0,sub.Length);
        }

        [Fact]
        public void Failure_OnRemoveNotExistedInCollectionNode()
        {
            Assert.Throws<Exception>(() =>
            {
                var failNode = new Node() {Value = 2};
                MyLinkedList sub = new(1, 2, 3);
                sub.RemoveNode(failNode);
            });
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void Failure_IndexNotInRange(int failIndex)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                MyLinkedList sub = new(1, 2, 3);
                _ = sub[failIndex];
            });
        }
        
        [Theory]
        [InlineData(-1,2)]
        [InlineData(1,10)]
        [InlineData(1,4)]
        [InlineData(1,8)]
        [InlineData(2,1)]
        public void Failure_RangeNotInRange(int failStartIndex, int failLastIndex)
        {
            Assert.Throws<Exception>(() =>
            {
                MyLinkedList sub = new(1, 2, 3);
                _ = sub[failStartIndex..failLastIndex];
            });
        }
            
        [Fact]
        public void Check_IndexEnumerationFunctionality()
        {
            var array = new int[] {1, 2, 3, 4, 6, 2, 1, 4, 6};
            MyLinkedList sub = new(array);

            var indexCheck = new int[sub.Length];
            for (var i = 0; i < sub.Length; i++)
            {
                indexCheck[i] = sub[i];
            }
            Assert.Equal(array,indexCheck);
        }
        
        [Fact]
        public void Check_GetEnumeratorFunctionality()
        {
            var array = new int[] {1, 2, 3, 4, 6, 2, 1, 4, 6};
            MyLinkedList sub = new(array);

            var enumeratorCheck = new List<int>();
            foreach (var node in sub)
                enumeratorCheck.Add(node.Value);
            Assert.Equal(array,enumeratorCheck.ToArray());
        }
        
        [Fact]
        public void Check_AsEnumerableFunctionality()
        {
            var array = new int[] {1, 2, 3, 4, 6, 2, 1, 4, 6};
            MyLinkedList sub = new(array);

            var enumerableCheck = sub.AsIEnumerable().Select(x => x.Value).ToArray();
            Assert.Equal(array,enumerableCheck);
        }
        
        [Fact]
        public void Check_RangeFunctionality()
        {
            var array = new int[] {1, 2, 3, 4, 6, 2, 1, 4, 6};
            MyLinkedList sub = new(array);

            var range = sub[..];
            Assert.Equal(array,range);
        }
    }
}