using System.Collections.Generic;
using Xunit;

namespace Task3Tests
{
    public class FibonacciTests
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]{0,0};
            yield return new object[]{1,1};
            yield return new object[]{2,1};
            yield return new object[]{3,2};
            yield return new object[]{4,3};
            yield return new object[]{5,5};
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void RecursiveFibonacciTest(int number, int expected)
        {
            var result = Task3.Program.RecursiveFibonacci(number);
            
            Assert.Equal(result,expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void LoopFibonacciTest(int number, int expected)
        {
            var result = Task3.Program.LoopFibonacci(number);
            
            Assert.Equal(result,expected);
        }
    }
}