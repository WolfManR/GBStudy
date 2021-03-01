using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
        }
    }
    
    public class BenchmarkClass
    {
        private const int Words = 9;
        private const int Sentences = 1;
        private const int Strings = 10000;
        
        private static string[] _array = LoremNET.Lorem.Paragraphs(Words, Sentences, Strings).ToArray();
        private static HashSet<string> _hashSet = LoremNET.Lorem.Paragraphs(Words, Sentences, Strings).ToHashSet();

        
        
        [Benchmark]
        public void Search_In_Array()
        {
            
        }
        
        [Benchmark]
        public void Search_In_HashSet()
        {
            
        }
    }
}