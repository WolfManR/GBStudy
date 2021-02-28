using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}

namespace Task2.SearchAlgorithms
{
    public static class SearchAlgo
    {
        public static int BinarySearch(this int[] inputArray, int searchValue)
        {
            var min = 0;                                   // O(1) - ignore (one time behavior)                     
            var max = inputArray.Length - 1;               // O(1) - ignore (one time behavior)
            while (min <= max)                             // O(log2(n)) - every iteration cut on half
            {                                              // 
                var mid = (min + max) / 2;                 // O(1) - needed?
                if (searchValue == inputArray[mid])        // 
                {                                          // 
                    return mid;                            // O(1) - ignore (one time behavior)
                }                                          // 
                else if (searchValue < inputArray[mid])    // 
                {                                          // 
                    max = mid - 1;                         // O(1) - needed?
                }                                          // 
                else                                       // 
                {                                          // 
                    min = mid + 1;                         // O(1) - needed?
                }                                          // 
            }                                              // 
            return -1;                                     //  O(1) - ignore (one time behavior)
        }                                                  //
    }                                                      //  O(log2(n))?
}