using System.Collections.Generic;
using System.IO;
using Task3.Interfaces;

namespace Task3.Services
{
    public class FileReader : IFileReader
    {
        public IEnumerable<string> TakeFiles(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories);
            foreach (var file in files)
                yield return file;
        }

        public bool ReadFile(FileInfo file)
        {
            try
            {
                using var fs = file.OpenRead();
                using var sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                    _ = sr.Read();
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }
}