using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        public static int  StrangeSum(int[] inputArray)
        {
            int sum = 0;                                                 // o(1) - ignore happens one time
                                                                         //
            for (int i = 0; i < inputArray.Length; i++)                  // O(n)
            {                                                            //
                for (int j = 0; j < inputArray.Length; j++)              // O(n)
                {                                                        //
                    for (int k = 0; k < inputArray.Length; k++)          // O(n)
                    {                                                    //
                        int y = 0;                                       //
                                                                         //
                        if (j != 0)                                      //
                        {                                                //
                            y = k / j;                                   // O(1)
                        }                                                //
                                                                         
                        sum += inputArray[i] + i + k + j + y;            // O(1)
                    }                                                    // inputArray[i],y - important?
                }                                                        //
            }                                                            //
                                                                         
            return sum;                                                  // O(1) - ignore happens one time
        }
    }
}                                                                        // O(N^3)