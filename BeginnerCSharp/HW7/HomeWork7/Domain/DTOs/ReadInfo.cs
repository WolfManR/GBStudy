using System;

namespace Domain.DTOs
{
    public record ReadInfo
    {
        public string File { get; init; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public long Length { get; init; }
        public string Path { get; init; }
    };
}