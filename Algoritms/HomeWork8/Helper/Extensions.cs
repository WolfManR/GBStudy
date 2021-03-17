// ReSharper disable once CheckNamespace

using System.Collections.Generic;

namespace System
{
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
            List<int> cache = new();
            for (var i = 0; i < self.Length; i++)
            {
                int value;
                do
                {
                    value = Rand.Next(min, max);
                } while (cache.Contains(value));
                cache.Add(value);

                self[i] = value;
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
}