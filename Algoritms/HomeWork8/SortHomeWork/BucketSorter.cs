using System;
using System.Collections.Generic;

namespace SortHomeWork
{
    public static class BucketSorter
    {
        public static int[] Sort(int[] self, int numberOfBuckets)
        {
            var (min, max) = self.GetMinAndMaxOfArray();
            var bucketSize = (max - min) / numberOfBuckets;

            self = MergeBuckets(
                SortBuckets(
                    SeparateOnBuckets(self, min, bucketSize, numberOfBuckets)),
                self.Length);

            return self;
        }

        private static IReadOnlyList<List<int>> SeparateOnBuckets(int[] array, int minValue, int bucketSize, int numberOfBuckets)
        {
            List<List<int>> buckets = new();

            for (var i = 0; i < numberOfBuckets; i++)
                buckets.Add(new());
                
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

        private static IReadOnlyList<List<int>> SortBuckets(IReadOnlyList<List<int>> buckets)
        {
            for (var i = 0; i < buckets.Count; i++)
            {
                if (buckets.Count > 0)
                    buckets[i].Sort();
            }

            return buckets;
        }

        private static int[] MergeBuckets(IReadOnlyList<List<int>> buckets, int originalArraySize)
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
}