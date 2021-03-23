using System;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[8,8];
            arr
                .PrintArray()
                .WaysCount((7,7),out var matrix1);
            matrix1.PrintArray();

            
            var blocks = new (int y, int x)[] {(0,4),(3,0),(3,2),(5,0), (4,4), (3,2), (6,7)};
            
            var mapWithBlocks = new int[8,8];
            for (var i = 0; i < blocks.Length; i++)
            {
                var (x, y) = blocks[i];
                mapWithBlocks[y, x] = 1;
            }
            mapWithBlocks.PrintArray();
            
            arr
                .WaysCount((7, 7), out var matrix2, blocks);
            matrix2.PrintArray();
        }
    }

    public static class Extensions
    {
        public static int WaysCount(this int[,] self,(int x, int y) endPoint, out int[,] matrix, (int,int)[] blocks = null)
        {
            var columns = self.GetLength(0);
            var rows = self.GetLength(1);
            
            matrix = new int[columns, rows];

            int result;
            if (blocks is null)
            {
                matrix[0, 0] = 1;
                result = CountWays(matrix, endPoint.y, endPoint.x);
            }
            else
                result = CountWays(matrix, endPoint.y, endPoint.x, new int[columns, rows].FillWithBlocks(blocks));
            return result;
        }

        

        private static int CountWays(int[,] matrix, int row, int column, int[,] blocks)
        {
            if (blocks[column, row] == 0) 
                return matrix[column, row] = 0;
            if (matrix[column, row] > 0)
                return matrix[column, row];
            
            if (row == 0)
            {
                if (column > 0 && matrix[column - 1, 0] == 0) 
                    return matrix[column, row] = CountWays(matrix, row, column - 1,blocks);
                return matrix[column, row] = 1;
            }

            if (column == 0)
            {
                if (row > 0 && matrix[column, row - 1] == 0)
                    return matrix[column, row] = CountWays(matrix, row - 1, column,blocks);
                return matrix[column, row] = 1;
            }
                
            return matrix[column, row] = CountWays(matrix, row - 1, column,blocks) + CountWays(matrix, row, column - 1,blocks);
        }

        private static int CountWays(int[,] matrix, int row, int column)
        {
            if (matrix[column, row] > 0)
                return matrix[column, row];
            
            if (row == 0) return matrix[column, row] = 1;
            if (column == 0) return matrix[column, row] = 1;
            
            return matrix[column, row] = CountWays(matrix, row - 1, column) + CountWays(matrix, row, column - 1);
        }

        public static int[,] FillWithBlocks(this int[,] self, (int x, int y)[] blocks)
        {
            for (var i = 0; i < self.GetLength(0); i++)
            {
                for (var j = 0; j < self.GetLength(1); j++)
                {
                    self[j, i] = 1;
                }
            }

            for (var i = 0; i < blocks.Length; i++)
            {
                var (x, y) = blocks[i];
                self[y, x] = 0;
            }

            return self;
        }
        
        
        
        private const char RowSplitterChar = '-';
        private const char ColumnBorderChar = '|';

        public static T[,] PrintArray<T>(this T[,] self)
        {
            StringBuilder rowBuilder = new();
            
            var columnCount = self.GetLength(0);
            var rowCount = self.GetLength(1);
            
            for (var i = 0; i < rowCount; i++)
            {
                rowBuilder.Append(ColumnBorderChar);
                for (var j = 0; j < columnCount; j++)
                {
                    var value = self[j, i].ToString();
                    rowBuilder.Append($"{new string(' ', rowCount / 2 - value.Length + 1)}{value} {ColumnBorderChar}");
                }
                
                var length = rowBuilder.Length;
                if(i == 0)PrintSplitter(RowSplitterChar,length);
                Console.WriteLine(rowBuilder);
                PrintSplitter(RowSplitterChar,length);
                rowBuilder.Clear();
            }
            return self;
        }

        private static void PrintSplitter(char splitterChar, int length)
        {
            for (var i = 0; i < length; i++)
            {
                Console.Write(splitterChar);
            }

            Console.WriteLine();
        }
    }
}