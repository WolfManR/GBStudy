using System;

namespace Task3.Models
{
    public record ReadInfo
    {
        public string File { get; init; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public long Length { get; set; }
        public string Path { get; set; }
    };
}