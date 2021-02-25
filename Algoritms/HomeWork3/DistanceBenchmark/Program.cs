using BenchmarkDotNet.Running;

namespace DistanceBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        
        // TestCount = 100_000
        //
        // |                   Method |      Mean |    Error |    StdDev |
        // |------------------------- |----------:|---------:|----------:|
        // |              Float_Class | 131.25 us | 5.659 us | 15.775 us |
        // |             Float_Struct |  84.26 us | 1.424 us |  1.332 us |
        // |            Double_Struct | 110.22 us | 2.186 us |  4.367 us |
        // | Float_Struct_WithoutSQRT |  84.57 us | 1.396 us |  1.306 us |
        //
        // * Warnings *
        // MultimodalDistribution
        //     BenchmarkClass.Float_Class: Default -> It seems that the distribution is bimodal (mValue = 3.7)

    }
}