using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SortHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[14];
            arr.Fill(2, 30).Print().Bucket(4).Print();
        }
    }

    public static class Sorts
    {
        public static int[] Bucket(this int[] self, int numberOfBuckets)
        {
            var (min, max) = self.GetMinAndMaxOfArray();
            var bucketSize = (max - min) / numberOfBuckets;
            List<List<int>> buckets = new();

            for (var i = 0; i < numberOfBuckets; i++)
                buckets.Add(new());

            self = MergeBuckets(
                        SortBuckets(
                            SeparateOnBuckets(self, min, bucketSize, buckets)),
                        self.Length);

            return self;

            // Actual methods can be pulled out to Extension method's with support of Fluent Call
            static IReadOnlyList<List<int>> SeparateOnBuckets(int[] array, int minValue, int bucketSize, IReadOnlyList<List<int>> buckets)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    var bucketIndex = (array[i] - minValue) / bucketSize;
                    if (array[i] != minValue && bucketIndex > 0)
                        buckets[bucketIndex - 1].Add(array[i]);
                    else
                        buckets[bucketIndex].Add(array[i]);
                }

                return buckets;
            }

            static IReadOnlyList<List<int>> SortBuckets(IReadOnlyList<List<int>> buckets)
            {
                for (var i = 0; i < buckets.Count; i++)
                {
                    if (buckets.Count > 0)
                        buckets[i].Sort();
                }

                return buckets;
            }

            static int[] MergeBuckets(IReadOnlyList<List<int>> buckets, int originalArraySize)
            {
                var resultArray = new int[originalArraySize];
                var k = 0;
                for (var i = 0; i < buckets.Count; i++)
                {
                    for (var j = 0; j < buckets[i].Count; j++)
                    {
                        resultArray[k++] = buckets[i][j];
                    }
                }

                return resultArray;
            }
        }


        public static int[] External(this int[] self)
        {
            
            
            return self;
        }


        private static (int min, int max) GetMinAndMaxOfArray(this int[] self)
        {
            var max = self[0];
            var min = self[0];
            for (var i = 1; i < self.Length; i++)
            {
                if (self[i] > max)
                    max = self[i];
                if (self[i] < min)
                    min = self[i];
            }

            return (min, max);
        }
    }

    public class ExternalSorter
    {
        private string fileToRead;
        private int originalFileSize;
        private long bucketSize;
        private List<string> pathsToTempFiles = new ();
        void ReadFile()
        {
            var fs = new FileStream(fileToRead, FileMode.Open);
            var sr = new StreamReader(fs);
            var length = fs.Length;
            bucketSize = length / 5;

            if (!Directory.Exists("Temp")) 
                Directory.CreateDirectory("Temp");

            const string tempFileFormatter = @"Temp/temp{0}.txt";
            var currentBucket = 0;
            while (!sr.EndOfStream)
            {
               var bucket =  FillBucket(sr, bucketSize, currentBucket == 4);
                
               bucket.Sort();

               var bucketPath = string.Format(tempFileFormatter, currentBucket++);
               pathsToTempFiles.Add(bucketPath);
               SaveBucketToFile(bucketPath,bucket);
            }


            static List<int> FillBucket(StreamReader stream, long bucketSize, bool isLastBucket)
            {
                List<int> bucket = new();
                var i = 0;
                do
                {
                    var line = stream.ReadLine();
                    if (!int.TryParse(line, out var number)) continue;
                    
                    bucket.Add(number);
                    if(!isLastBucket)
                        i++;
                } while (i < bucketSize || !stream.EndOfStream);

                return bucket;
            }

            static void SaveBucketToFile(string filePath, List<int> bucket)
            {
                using var sw = new StreamWriter(File.Create(filePath));
                for (var i = 0; i < bucket.Count; i++)
                {
                    sw.WriteLine(bucket[i]);
                }
            }
        }

        void MergeBuckets(string outputPath)
        {
            if (pathsToTempFiles.Count <= 0)
                throw new InvalidOperationException("There no one bucket");
            
            
        }
    }
}