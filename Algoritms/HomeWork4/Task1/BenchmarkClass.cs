using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Task1
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class BenchmarkClass
    {
        private const int Words = 9;
        private const int Sentences = 1;
        private const int Strings = 10000;
        
        private static readonly string SearchString;
        private static readonly string[] Array;
        private static readonly HashSet<string> HashSet;
        static BenchmarkClass()
        {
            var strings = LoremNET.Lorem.Paragraphs(Words, Sentences, Strings);
            var rndIndex = new Random().Next(Strings - 1);
            SearchString = strings.ElementAtOrDefault(rndIndex);
            Array = strings.ToArray();
            HashSet = strings.ToHashSet();
        }

        
        [Benchmark]
        public void Search_In_Array_With_LINQ()
        {
            _ = Array.Contains(SearchString);
        }
        
        [Benchmark]
        public void Search_In_Array()
        {
            for (var i = 0; i < Array.Length; i++)
            {
                if (Array[i] == SearchString) return;
            }
        }
        
        [Benchmark]
        public void Search_In_Array_With_Foreach()
        {
            foreach (var str in Array)
            {
                if (str == SearchString) return;
            }
        }
        
        [Benchmark]
        public void Search_In_Array_With_Reverse_For()
        {
            for (var index = Array.Length - 1; index >= 0; index--)
            {
                if (Array[index] == SearchString) return;
            }
        }
        
        [Benchmark]
        public void Search_In_HashSet()
        {
            _ = HashSet.Contains(SearchString);
        }
    }
}