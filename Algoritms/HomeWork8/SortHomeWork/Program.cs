using System;
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
            
            // Bucket Sort
            Console.WriteLine("\nBucket Sort");
            
            arr.Bucket(4).Print();
            

            // External Sort
            Console.WriteLine("\nExternal Sort");
            
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

            // Print sorted output file to console
            using (var sr = new StreamReader(File.OpenRead(outputFilePath)))
            {
                while (!sr.EndOfStream)
                {
                    Console.Write(sr.ReadLine() + " ");
                }
            }
        }
    }
}