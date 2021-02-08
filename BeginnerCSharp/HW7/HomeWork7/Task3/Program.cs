using System.Diagnostics;
using System.IO;
using Task3.Services;
using static System.Console;

namespace Task3
{
    class Program
    {
        private const string CheckInfoFilePath = "CheckInfo.json";
        
        
        static void Main(string[] args)
        {
            if (!HandleUserInputPath(out var path)) return;
            
            var watch = new Stopwatch();
            watch.Start();

            var fileReader = new FileReader();
            var checkSavior = new CheckInfoSavior(CheckInfoFilePath);
            var checker = new Checker(fileReader,checkSavior);
            
            var readedCounter = 0;
            const string readedFormatter = "readed {0}";
            
            checker.OnFileReaded += () =>
            {
                WriteLine(readedFormatter, ++readedCounter);
            };
            checker.WorkExceptionHandler += static exception =>
            {
                WriteLine(exception.Message);
                return true;
            };
            
            checker.StartCheck(path);
            
            watch.Stop();
            WriteLine($"Elapsed time {watch.Elapsed.TotalMilliseconds}");
        }

        
        private static bool HandleUserInputPath(out string path)
        {
            path = null;
            string input;
            while (true)
            {
                WriteLine("input path to check, or Q if wanna exit");
                input = ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    WriteLine("incorrect path");
                    continue;
                }

                if (input.ToLower() == "q") return false;

                if (Path.HasExtension(input) && !Directory.Exists(input))
                {
                    WriteLine("incorrect path");
                    continue;
                }

                break;
            }

            path = input;
            return true;
        }
    }
}