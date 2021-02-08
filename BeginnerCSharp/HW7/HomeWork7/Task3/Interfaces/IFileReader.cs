using System.Collections.Generic;
using System.IO;

namespace Task3.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<string> TakeFiles(string directory);
        bool ReadFile(FileInfo file);
    }
}