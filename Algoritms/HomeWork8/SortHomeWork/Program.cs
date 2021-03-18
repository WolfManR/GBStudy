using System;
using System.Collections.Generic;
using System.IO;

namespace SortHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[14];
            arr.Fill(2, 30).Print();
            
            // prepare for External Sort
            const string outputDirectory = "ExternalSortTest";
            var fileToSort = $"{outputDirectory}/toSort.txt";
            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
            using (var sw = new StreamWriter(File.Create(fileToSort)))
            {
                for (var i = 0; i < arr.Length; i++)
                {
                    sw.WriteLine(arr[i]);
                }
            }
            
            // // Bucket Sort
            // arr.Bucket(4).Print();
            
            // External Sort
            var outputFilePath = Path.Combine(Path.GetDirectoryName(fileToSort), "output.txt");
            try
            {
                Sorts.External(fileToSort, outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            using (var sr = new StreamReader(File.OpenRead(outputFilePath)))
            {
                while (!sr.EndOfStream)
                {
                    Console.Write(sr.ReadLine() + " ");
                }
            }
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
            static IReadOnlyList<List<int>> SeparateOnBuckets(int[] array, int minValue, int bucketSize,
                IReadOnlyList<List<int>> buckets)
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

        public static void External(string filePath, string outputFilePath)
        {
            ExternalSorter sorter = new(5);
            sorter.Sort(filePath, outputFilePath);
        }

        
        
        
        private class ExternalSorter
        {
            private readonly int _bucketSize;
            private readonly List<string> _pathsToTempFiles = new();
            private int _numberOfBuckets;
            private static readonly string TempFileFormatter = TempDirectory + @"/temp{0}.txt";
            private const string TempDirectory = "Temp";

            public ExternalSorter(int bucketSize) => _bucketSize = bucketSize;


            public void Sort(string fileToSort, string outputFilePath)
            {
                ReadFile(fileToSort);
                MergeBuckets(outputFilePath);
                CleanAfterWork();
            }

            
            
            private void ReadFile(string fileToRead)
            {
                using var fs = new FileStream(fileToRead, FileMode.Open);
                using var sr = new StreamReader(fs);

                if (!Directory.Exists(TempDirectory))
                    Directory.CreateDirectory(TempDirectory);


                var currentBucketIndex = 0;

                while (!sr.EndOfStream)
                {
                    var bucket = FillBucket(sr, _bucketSize);
                    _numberOfBuckets++;
                    bucket.Sort();

                    var bucketPath = string.Format(TempFileFormatter, currentBucketIndex++);
                    _pathsToTempFiles.Add(bucketPath);
                    SaveBucketToFile(bucketPath, bucket);
                }


                static List<int> FillBucket(StreamReader stream, long bucketSize)
                {
                    List<int> bucket = new();
                    var i = 0;
                    while (i < bucketSize && !stream.EndOfStream)
                    {
                        var line = stream.ReadLine();
                        if (!int.TryParse(line, out var number)) continue;

                        bucket.Add(number);
                        i++;
                    } 
                    
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

            private void MergeBuckets(string outputPath)
            {
                if (_pathsToTempFiles.Count <= 0)
                    throw new InvalidOperationException("There no one bucket");

                var numbersFromBuckets = new int?[_numberOfBuckets];
                var buckets = new StreamReader[_numberOfBuckets];
                for (var i = 0; i < _numberOfBuckets; i++)
                {
                    var stream = new StreamReader(File.OpenRead(_pathsToTempFiles[i]));
                    buckets[i] = stream;
                    numbersFromBuckets[i] = GetNumber(stream);
                }

                
                
                using var sw = new StreamWriter(File.Create(outputPath));
                while (true)
                {
                    var (min, minBucketIndex) = GetMin(numbersFromBuckets);
                    if (min is null) break;
                    sw.WriteLine((int) min);
                    numbersFromBuckets[minBucketIndex] = GetNumber(buckets[minBucketIndex]);
                }

                for (var i = 0; i < buckets.Length; i++)
                {
                    buckets[i].Dispose();
                }
                
                

                static int? GetNumber(StreamReader stream)
                {
                    if (stream.EndOfStream) return null;

                    var line = stream.ReadLine();
                    if (int.TryParse(line, out var firstNumber))
                        return firstNumber;

                    throw new("Not a number Exception");
                }

                static (int? min, int minBucketIndex) GetMin(int?[] numbers)
                {
                    var min = numbers[0];
                    var minBucketIndex = 0;
                    for (var i = 1; i < numbers.Length; i++)
                    {
                        if (min is not null && numbers[i] >= min) continue;
                        min = numbers[i];
                        minBucketIndex = i;
                    }

                    return (min, minBucketIndex);
                }
            }

            private void CleanAfterWork()
            {
                var paths = _pathsToTempFiles;
                for (var i = 0; i < paths.Count; i++)
                {
                    if(File.Exists(paths[i]))
                        File.Delete(paths[i]);
                }

                if (!Directory.Exists(TempDirectory)) return;
                var isNotClean = Directory.GetFileSystemEntries(TempDirectory).Length > 0;
                if(isNotClean) return;
                Directory.Delete(TempDirectory);
            }
        }
    }
}