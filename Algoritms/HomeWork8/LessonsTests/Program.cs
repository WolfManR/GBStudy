using System;

namespace LessonsTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // generic swap extension test
            // var first = 56;
            // var second = 984;
            //
            // Console.WriteLine($"{first} {second}");
            // first.Swap(ref second);
            // Console.WriteLine($"{first} {second}");
            
            var arr = new int[10]/*{1,0,2,4,7,3,2}*/;
            arr
                .Fill(40, 800)
                .Print()
                .UpdateInsertSort()
                // .InsertionSort()
                // .QuickSort()
                // .HeapSort()
                .Print();
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Seeded Random
        /// </summary>
        private static readonly Random Rand = new (800);
        
        /// <summary>
        /// Fill array with pseudo random numbers in range of <paramref name="min"/> and <paramref name="max"/>
        /// </summary>
        /// <param name="self">Array</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns><paramref name="self"/></returns>
        public static int[] Fill(this int[] self, int min, int max)
        {
            for (var i = 0; i < self.Length; i++)
            {
                self[i] = Rand.Next(min, max);
            }
            return self;
        }
        
        /// <summary>
        /// Prints elements of array in line to console
        /// </summary>
        /// <param name="self">Array</param>
        /// <returns><paramref name="self"/></returns>
        public static int[] Print(this int[] self)
        {
            Console.WriteLine();
            foreach (var item in self)
                Console.Write($"{item}  ");
            Console.WriteLine();
            return self;
        }

        /// <summary>
        /// Swap <paramref name="self"/> value with <paramref name="other"/> value by reference
        /// </summary>
        /// <param name="self">Reference to value of self</param>
        /// <param name="other">Reference to value of other operand</param>
        /// <typeparam name="T">Struct type</typeparam>
        public static void Swap<T>(ref this T self, ref T other) where T : struct
        {
            var temp = self;
            self = other;
            other = temp;
        }
    }
    
    public static class SortExtensions
    {
        public static int[] UpdateInsertSort(this int[] self) // Not working
        {
            var n = self.Length;
            
            for (var i = 1; i < n; i++)
            {
                if (self[i - 1] <= self[i]) continue;
                
                var x = self[i];

                var left = 0;
                var right = i - 1;
                var middle = right / 2;

                if (self[middle] < x)
                    left = middle + 1;
                else
                    right = middle - 1;

                if (left < right) continue;
                
                for (var j = i - 1; j >= left; j--)
                {
                    self[j + 1] = self[j];
                }
                self[left] = x;
            }

            return self;
        }
        
        public static int[] InsertionSort(this int[] self)
        {
            for (var i = 1; i < self.Length; i++)
            {
                int j;
                var buf = self[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (self[j] < buf)
                        break;

                    self[j + 1] = self[j];
                }
                self[j + 1] = buf;
            }

            return self;
        }

        public static int[] QuickSort(this int[] self)
        {
            Sort(self, 0, self.Length - 1);
            return self;
            
            
            // algorithm
            static void Sort(int[] array, int first, int last)
            {
                int i = first, 
                    j = last, 
                    x = array[(first + last) / 2];

                do
                {
                    while (array[i] < x)
                        i++;
                    while (array[j] > x)
                        j--;

                    if (i > j) 
                        continue;
                
                    if (array[i] > array[j])
                        array[i].Swap(ref array[j]);

                    i++;
                    j--;
                } while (i <= j);

                if (i < last)
                    Sort(array, i, last);
                if (first < j)
                    Sort(array, first, j);
            }
        }
        
        
        public static int[] HeapSort(this int[] self)
        {
            var n = self.Length;
            
            for (var i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(self, n, i);
            }

            for (var i = n - 1; i >= 0; i--)
            {
                self[0].Swap(ref self[i]);
                
                Heapify(self, i, 0);
            }

            return self;
            
            
            // algorithm
            static void Heapify(int[] array, int n, int i)
            {
                var largest = i;
                var left = (i * 2) + 1;
                var right = (i * 2) + 2;

                if (left < n && array[left] > array[largest])
                    largest = left;

                if (right < n && array[right] > array[largest])
                    largest = right;

                if (largest == i) return;
            
                array[i].Swap(ref array[largest]);
            
                Heapify(array, n, largest);
            }
        }
    }
}