using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Application.Services;
using Infrastructure.Services;
using static System.Console;

namespace Task3
{
    class Program
    {
        private const string CheckInfoFilePath = "CheckInfo.json";
        private static Checker _checkerService;
        private static int _readedCounter = 0;
        const string ReadedFormatter = "readed {0}";
        
        
        static void Main(string[] args)
        {
            if (!HandleUserInputPath(out var path)) return;
            
            var watch = new Stopwatch();
            watch.Start();

            _checkerService.StartCheck(path);
            
            watch.Stop();
            WriteLine($"Elapsed time {watch.Elapsed.TotalMilliseconds}");
        }

        
        [ModuleInitializer]
        public static void InitCheckerService()
        {
            var fileReader = new FileReader();
            var checkSavior = new CheckInfoSavior(CheckInfoFilePath);
            _checkerService = new (fileReader,checkSavior);
            _checkerService.OnFileReaded += () =>
            {
                WriteLine(ReadedFormatter, ++_readedCounter);
            };
            _checkerService.WorkExceptionHandler += static exception =>
            {
                WriteLine(exception.Message);
                return true;
            };
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