using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task3.Interfaces;
using Task3.Models;

namespace Task3.Services
{
    public class Checker
    {
        private readonly IFileReader _fileReader;
        private readonly ICheckInfoSavior _checkInfoSavior;
        public event Action OnFileReaded;
        public event Func<Exception, bool> WorkExceptionHandler;
        
        public Checker(IFileReader fileReader, ICheckInfoSavior checkInfoSavior)
        {
            _fileReader = fileReader;
            _checkInfoSavior = checkInfoSavior;
        }

        
        public void StartCheck(string path)
        {
            try
            {
                var previousCheckList = LoadPreviousCheck(path);
                var currentCheckList = new List<ReadInfo>();
            
                var files = _fileReader.TakeFiles(path);
            
                CheckFiles(files, previousCheckList, currentCheckList);

                SaveCheckResult(currentCheckList, path);
            }
            catch (Exception e)
            {
                if (WorkExceptionHandler?.Invoke(e) == false)
                {
                    throw;
                }
            }
        }
        
        
        private void CheckFiles(IEnumerable<string> files, IReadOnlyCollection<ReadInfo> previousCheckList, List<ReadInfo> currentCheckList)
        {
            foreach (var filePath in files)
            {
                var file = new FileInfo(filePath);
                var readInfo = ToReadInfo(file);

                var previousCheck = previousCheckList?.FirstOrDefault(info => info == readInfo);
                if (previousCheck != null)
                {
                    currentCheckList.Add(readInfo);
                    Console.Clear();
                    OnFileReaded?.Invoke();
                    continue;
                }

                _fileReader.ReadFile(file);

                file.Refresh();
                readInfo.LastAccessTime = file.LastAccessTime;
                readInfo.LastWriteTime = file.LastWriteTime;
                currentCheckList.Add(readInfo);

                Console.Clear();
                OnFileReaded?.Invoke();
            }
        }
        
        private IReadOnlyCollection<ReadInfo> LoadPreviousCheck(string path)
        {
            var previous = _checkInfoSavior.LoadCheckInfo();

            return previous.Previous.CheckPath != path 
                ? null 
                : previous.Info;
        }

        private void SaveCheckResult(List<ReadInfo> currentCheckList, string path)
        {
            CheckInfo currentCheck = new()
            {
                Info = currentCheckList, 
                Previous = new(path, DateTime.Now)
            };
            
            _checkInfoSavior.SaveCheckInfo(currentCheck);
        }
        
        private static ReadInfo ToReadInfo(FileInfo self) =>
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