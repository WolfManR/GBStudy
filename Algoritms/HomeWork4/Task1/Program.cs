using BenchmarkDotNet.Running;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
        }

        //  Results of test
        //
        //  |                           Method |         Mean |      Error |       StdDev |
        //  |--------------------------------- |-------------:|-----------:|-------------:|
        //  |                Search_In_HashSet |     32.70 ns |   0.615 ns |     0.545 ns |
        //  |     Search_In_Array_With_Foreach | 40,079.69 ns | 753.428 ns |   806.160 ns |
        //  | Search_In_Array_With_Reverse_For | 45,594.94 ns | 879.993 ns |   823.146 ns |
        //  |                  Search_In_Array | 46,408.10 ns | 879.832 ns |   822.996 ns |
        //  |        Search_In_Array_With_LINQ | 49,904.22 ns | 978.457 ns | 1,861.615 ns |
        //
        //  * Warnings *
        //  MultimodalDistribution
        //      BenchmarkClass.Search_In_Array_With_LINQ: Default -> It seems that the distribution is bimodal (mValue = 3.75)
    }
}