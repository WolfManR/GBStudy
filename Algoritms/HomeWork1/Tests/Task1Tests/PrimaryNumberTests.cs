using Xunit;

namespace Task1Tests
{
    public class PrimaryNumberTests
    {
        [Theory]
        [InlineData(2,true)]
        [InlineData(12,false)]
        [InlineData(-2,true)]
        [InlineData(30,false)]
        public void IsNumberPrimaryTest(int number, bool expected)
        {
            var result = Task1.Program.IsPrimeNumber(number);
            
            Assert.Equal(result,expected);
        }
    }
}