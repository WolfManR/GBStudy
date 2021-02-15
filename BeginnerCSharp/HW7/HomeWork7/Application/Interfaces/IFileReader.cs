using System.Collections.Generic;
using System.IO;

namespace Application.Interfaces
{
    /// <summary>
    /// Files collect and read handler
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// Collect files from <paramref name="directory"/>
        /// </summary>
        /// <param name="directory">Directory from which need to collect files</param>
        /// <returns>Enumeration of file path's</returns>
        IEnumerable<string> TakeFiles(string directory);
        
        /// <summary>
        /// Read <paramref name="file"/> handler
        /// </summary>
        /// <param name="file">File to read</param>
        /// <returns>true if file successfully read, false if not</returns>
        bool ReadFile(FileInfo file);
    }
}