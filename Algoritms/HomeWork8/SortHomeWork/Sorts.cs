using System;
using System.Collections.Generic;

namespace SortHomeWork
{
    public static class Sorts
    {
        public static int[] Bucket(this int[] self, int numberOfBuckets) => 
            BucketSorter.Sort(self, numberOfBuckets);


        public static void External(string filePath, string outputFilePath)
        {
            ExternalSorter sorter = new(5);  // bucket's size can be throw up to user decision if it need
            sorter.Sort(filePath, outputFilePath);
        }
    }
}