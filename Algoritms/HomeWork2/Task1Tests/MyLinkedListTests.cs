using Task1.ListRealization;
using Xunit;

namespace Task1Tests
{
    public class MyLinkedListTests
    {
        [Fact]
        public void LengthOfArrayUpdatesCorrectlyOnInitializingCollection()
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
        public void NewItemSuccessfullyAddedToEnd(int expected, int[] toAdd)
        {
            MyLinkedList sub = new();
            foreach (var number in toAdd)
                sub.AddNode(number);
            var last = sub[^0];
            Assert.Equal(expected,last);
        }

        [Theory]
        [InlineData(3,new[]{2,3})]
        [InlineData(2,new[]{2})]
        [InlineData(8,new[]{2,3,4,1,5,7,8})]
        public void SuccessfullyFindNode(int expected, int[] toAdd)
        {
            MyLinkedList sub = new(toAdd);
            var result = sub.FindNode(expected);
            Assert.Equal(expected,result.Value);
        }
        
        [Fact]
        public void NewItemSuccessfullyAddedAfterNode()
        {
            MyLinkedList sub = new(1, 2, 3);
            
        }
    }
}