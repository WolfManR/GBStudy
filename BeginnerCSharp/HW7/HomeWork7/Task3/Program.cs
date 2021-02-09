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
        static void Main(string[] args)
        {
            if (!HandleUserInputPath(out var path)) return;
            
            var watch = new Stopwatch();
            watch.Start();

            _checkerService.StartCheck(path);
            
            watch.Stop();
            WriteLine($"Elapsed time {watch.Elapsed.TotalMilliseconds}");
        }
        
        
        /// <summary>
        /// Path to file where program saved check result
        /// </summary>
        private const string CheckInfoFilePath = "CheckInfo.json";
        
        /// <inheritdoc cref="Checker"/>
        private static Checker _checkerService;
        
        /// <summary>
        /// Counter of readed files
        /// </summary>
        private static int _readedCounter = 0;
        
        /// <summary>
        /// formatter of message about readed files
        /// </summary>
        private const string ReadedFormatter = "readed {0}";
        
        
        
        /// <summary>
        /// Initialize main program module and it's dependencies to check files
        /// </summary>
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
        
        /// <summary>
        /// Get path to check from user and check that this path exists and it's correct, or return if user wanna exit
        /// </summary>
        /// <param name="path">Path to Directory that must be checked</param>
        /// <returns>true if path correct, false if user wanna leave program</returns>
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