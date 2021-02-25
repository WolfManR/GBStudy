using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using DistanceBenchmark.Points;

namespace DistanceBenchmark
{
    public class BenchmarkClass
    {
        private static readonly Random Random = new ();
        private const int TestDataCount = 100_000;

        // ReSharper disable InconsistentNaming
        private static readonly PointClass[] Float_Class_TestData = 
            Enumerable
                .Range(0, TestDataCount)
                .Select(_ => 
                    new PointClass(
                        (float)Random.NextDouble(),
                        (float)Random.NextDouble()))
                .ToArray();
        
        private static readonly PointStructFloat[] Float_Struct_TestData = 
            Enumerable
                .Range(0, TestDataCount)
                .Select(_ => 
                    new PointStructFloat(
                        (float)Random.NextDouble(),
                        (float)Random.NextDouble()))
                .ToArray();
        
        private static readonly PointStructDouble[] Double_Struct_TestData = 
            Enumerable
                .Range(0, TestDataCount)
                .Select(_ => 
                    new PointStructDouble(
                        Random.NextDouble(),
                        Random.NextDouble()))
                .ToArray();
        // ReSharper restore InconsistentNaming
        
        public static float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            var x = pointOne.X - pointTwo.X;
            var y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistance(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            var x = pointOne.X - pointTwo.X;
            var y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistance(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            var x = pointOne.X - pointTwo.X;
            var y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointDistance_WithoutSQRT(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            var x = pointOne.X - pointTwo.X;
            var y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        
        

        [Benchmark]
        public void Float_Class()
        {
            for (var i = 0; i < TestDataCount-1; i+=2)
            {
                PointDistance(Float_Class_TestData[i], Float_Class_TestData[i + 1]);
            }
        }
        
        [Benchmark]
        public void Float_Struct()
        {
            for (var i = 0; i < TestDataCount-1; i+=2)
            {
                PointDistance(Float_Struct_TestData[i], Float_Struct_TestData[i + 1]);
            }
        }
        
        [Benchmark]
        public void Double_Struct()
        {
            for (var i = 0; i < TestDataCount-1; i+=2)
            {
                PointDistance(Double_Struct_TestData[i], Double_Struct_TestData[i + 1]);
            }
        }
        
        [Benchmark]
        public void Float_Struct_WithoutSQRT()
        {
            for (var i = 0; i < TestDataCount-1; i+=2)
            {
                PointDistance_WithoutSQRT(Float_Struct_TestData[i], Float_Struct_TestData[i + 1]);
            }
        }
    }
}