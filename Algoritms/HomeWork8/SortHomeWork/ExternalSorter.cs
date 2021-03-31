using System;
using System.Collections.Generic;
using System.IO;

namespace SortHomeWork
{
    internal class ExternalSorter
    {
        private const string TempDirectory = "Temp";
        private const string TempFileFormatter = TempDirectory + @"/temp{0}.txt";

        private readonly List<string> _pathsToTempFiles = new();
        
        private readonly int _bucketSize;
        private int _numberOfBuckets;


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
            
            // Create temp files directory if it not exist
            if (!Directory.Exists(TempDirectory))
                Directory.CreateDirectory(TempDirectory);


            var currentBucketIndex = 0;

            // fill buckets, sort, and save it's to files
            while (!sr.EndOfStream)
            {
                var bucket = FillBucket(sr, _bucketSize);
                _numberOfBuckets++;
                bucket.Sort();

                var bucketPath = string.Format(TempFileFormatter, currentBucketIndex++);
                _pathsToTempFiles.Add(bucketPath);
                SaveBucketToFile(bucketPath, bucket);
            }


            // Local Functions
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
            
            // Fill array with first numbers from buckets
            for (var i = 0; i < _numberOfBuckets; i++)
            {
                var stream = new StreamReader(File.OpenRead(_pathsToTempFiles[i]));
                buckets[i] = stream;
                numbersFromBuckets[i] = GetNumber(stream);
            }

                
            // replace merge buckets to output file    
            using var sw = new StreamWriter(File.Create(outputPath));
            while (true)
            {
                var (min, minBucketIndex) = GetMin(numbersFromBuckets);
                if (min is null) break;
                sw.WriteLine((int) min);
                numbersFromBuckets[minBucketIndex] = GetNumber(buckets[minBucketIndex]);
            }

            // Dispose opened temp files
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i].Dispose();
            }
                
                
            // Local Functions
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
            // Delete temp files if it's exist
            var paths = _pathsToTempFiles;
            for (var i = 0; i < paths.Count; i++)
            {
                if(File.Exists(paths[i]))
                    File.Delete(paths[i]);
            }

            // Delete temp catalog if it exist and don't has item's in it
            if (!Directory.Exists(TempDirectory)) return;
            var isNotClean = Directory.GetFileSystemEntries(TempDirectory).Length > 0;
            if(isNotClean) return;
            Directory.Delete(TempDirectory);
        }
    }
}