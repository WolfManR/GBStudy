using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Console;

namespace Task3
{
    class Program
    {
        private const string CheckInfoFilePath = "CheckInfo.json";
        private static JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
        };
        
        static void Main(string[] args)
        {
            if (!HandleUserInputPath(out var path)) return;
            var watch = new Stopwatch();
            watch.Start();
            List<ReadInfo> previousCheckList = null;
            if (File.Exists(CheckInfoFilePath))
            {
                var previous = JsonSerializer.Deserialize<CheckInfo>(File.ReadAllText(CheckInfoFilePath));
                if (previous is not null && previous.Previous.CheckPath == path)
                    previousCheckList = previous.Info;
            }
            var currentCheckList = new List<ReadInfo>();
            
            var files = TakeFiles(path);
            
            var readedCounter = 0;
            const string readedFormatter = "readed {0}";
            
            foreach (var filePath in files)
            {
                var file = new FileInfo(filePath);
                var readInfo = file.ToReadInfo();
                
                var previousCheck = previousCheckList?.Find(info => info == readInfo);
                if (previousCheck != null)
                {
                    currentCheckList.Add(readInfo);
                    Clear();
                    WriteLine(readedFormatter,++readedCounter);
                    continue;
                }

                ReadFile(file);
                
                file.Refresh();
                readInfo.LastAccessTime = file.LastAccessTime;
                readInfo.LastWriteTime = file.LastWriteTime;
                currentCheckList.Add(readInfo);
                
                Clear();
                WriteLine(readedFormatter,++readedCounter);
            }

            CheckInfo currentCheck = new() {Info = currentCheckList, Previous = new(path, DateTime.Now)};
            var json = JsonSerializer.Serialize(currentCheck, options);
            File.Delete(CheckInfoFilePath);
            File.WriteAllText(CheckInfoFilePath,json);
            watch.Stop();
            Console.WriteLine($"Elapsed time {watch.Elapsed.TotalMilliseconds}");
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

        private static IEnumerable<string> TakeFiles(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
            foreach (var file in files)
                yield return file;
        }

        private static bool ReadFile(FileInfo file)
        {
            var buffer = new byte[4096];
            try
            {
                using var fs = file.OpenRead();
                using var sr = new BinaryReader(fs);
                while (sr.BaseStream.Position < sr.BaseStream.Length)
                    _ = sr.Read();
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }

    public class CheckInfo
    {
        public PreviousCheckInfo Previous { get; set; }
        public List<ReadInfo> Info { get; set; }
    }

    public record PreviousCheckInfo(string CheckPath, DateTime LastCheck);

    public record ReadInfo
    {
        public string File { get; init; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public long Length { get; set; }
        public string Path { get; set; }
    };

    public static class FileInfoExtensions
    {
        public static ReadInfo ToReadInfo(this FileInfo self) =>
            new()
            {
                File = self.Name,
                Path = self.FullName,
                LastAccessTime = self.LastAccessTime,
                LastWriteTime = self.LastWriteTime,
                Length = self.Length
            };
    }
}