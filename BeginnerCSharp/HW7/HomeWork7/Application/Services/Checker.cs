using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    /// <summary>
    /// Main Module to handle check files
    /// </summary>
    public class Checker
    {
        public Checker(IFileReader fileReader, ICheckInfoSavior checkInfoSavior)
        {
            _fileReader = fileReader;
            _checkInfoSavior = checkInfoSavior;
        }
        
        /// <inheritdoc cref="IFileReader"/>
        private readonly IFileReader _fileReader;
        
        /// <inheritdoc cref="ICheckInfoSavior"/>
        private readonly ICheckInfoSavior _checkInfoSavior;
        
        /// <summary>
        /// Handler of file end reading 
        /// </summary>
        public event Action OnFileReaded;
        
        /// <summary>
        /// Handler of exception while reading, if return true throw's Exception and stop work, if return false continue of check to next step
        /// </summary>
        public event Func<Exception, bool> WorkExceptionHandler;
        
        

        /// <summary>
        /// Start check process
        /// </summary>
        /// <param name="path">Path which must be checked</param>
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
        
        
        /// <summary>
        /// Process which check files
        /// </summary>
        /// <param name="files">Files that must be checked</param>
        /// <param name="previousCheckList">Previous check result information</param>
        /// <param name="currentCheckList">Current check result information</param>
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
        
        /// <summary>
        /// Load previous check result information using <see cref="ICheckInfoSavior"/> to handle it
        /// </summary>
        /// <param name="path">Path which must be checked</param>
        /// <returns>Returns previous check result if previous check was in same path as current, if not returns null</returns>
        private IReadOnlyCollection<ReadInfo> LoadPreviousCheck(string path)
        {
            var previous = _checkInfoSavior.LoadCheckInfo();

            return previous.PreviousCheckInfo.CheckPath != path 
                ? null 
                : previous.Info;
        }

        /// <summary>
        /// save current check result using <see cref="ICheckInfoSavior"/> to handle it
        /// </summary>
        /// <param name="currentCheckList">Current checked files</param>
        /// <param name="path">Path that was checked</param>
        private void SaveCheckResult(List<ReadInfo> currentCheckList, string path)
        {
            CheckInfo currentCheck = new()
            {
                Info = currentCheckList, 
                PreviousCheckInfo = new(path, DateTime.Now)
            };
            
            _checkInfoSavior.SaveCheckInfo(currentCheck);
        }
        
        /// <summary>
        /// Parse file information to read file information 
        /// </summary>
        /// <param name="self">File information</param>
        /// <returns>Read file information</returns>
        private static ReadInfo ToReadInfo(FileInfo self) =>
            new()
            {
                FileName = self.Name,
                Path = self.FullName,
                LastAccessTime = self.LastAccessTime,
                LastWriteTime = self.LastWriteTime,
                Length = self.Length
            };
    }
}