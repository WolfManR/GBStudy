using System.Collections.Generic;
using System.IO;

namespace Application.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<string> TakeFiles(string directory);
        bool ReadFile(FileInfo file);
    }
}