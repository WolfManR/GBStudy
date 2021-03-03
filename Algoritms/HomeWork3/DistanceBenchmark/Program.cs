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
        // |                   Method |      Mean |    Error |   StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
        // |------------------------- |----------:|---------:|---------:|---------:|------:|------:|------:|----------:|
        // |             Float_Struct |  74.84 us | 0.723 us | 0.604 us | 74.78 us |     - |     - |     - |         - |
        // | Float_Struct_WithoutSQRT |  75.58 us | 1.416 us | 1.325 us | 75.12 us |     - |     - |     - |         - |
        // |            Double_Struct |  89.78 us | 1.647 us | 1.896 us | 89.70 us |     - |     - |     - |         - |
        // |              Float_Class | 102.29 us | 3.407 us | 9.940 us | 97.11 us |     - |     - |     - |         - |

        // * Hints *
        // Outliers
        //     BenchmarkClass.Float_Struct: Default  -> 2 outliers were removed (78.25 us, 79.54 us)
        //     BenchmarkClass.Double_Struct: Default -> 3 outliers were removed (97.29 us..99.47 us)
        //     BenchmarkClass.Float_Class: Default   -> 2 outliers were removed (134.96 us, 145.04 us)


    }
}