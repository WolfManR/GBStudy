using Xunit;
using Task2.SearchAlgorithms;

namespace Task2Tests
{
    public class BinarySearchTests
    {
        private readonly int[] _arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        
        [Theory]
        [InlineData(2,3)]
        [InlineData(4,5)]
        [InlineData(1,2)]
        [InlineData(5,6)]
        [InlineData(7,8)]
        [InlineData(12,13)]
        public void SearchSuccessfullyFindIndexOfValue(int expectedIndex,int toSearch)
        {
            var index = _arr.BinarySearch(toSearch);
            
            Assert.Equal(expectedIndex,index);
        }
        
        
        [Theory]
        [InlineData(-1,0)]
        [InlineData(-1,14)]
        public void SearchFailFindIndexOfValue(int expectedIndex,int toSearch)
        {
            var index = _arr.BinarySearch(toSearch);
            
            Assert.Equal(expectedIndex,index);
        }
    }
}