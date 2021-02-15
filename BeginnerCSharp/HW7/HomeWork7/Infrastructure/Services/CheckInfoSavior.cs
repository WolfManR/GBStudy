using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Application.Interfaces;
using Domain.DTOs;

namespace Infrastructure.Services
{
    /// <inheritdoc/>
    public class CheckInfoSavior : ICheckInfoSavior
    {
        public CheckInfoSavior(string checkInfoFilePath) => _checkInfoFilePath = checkInfoFilePath;
        
        
        /// <summary>
        /// Cached path to file where saved check result
        /// </summary>
        private readonly string _checkInfoFilePath;
        
        /// <summary>
        /// Format options to serialization
        /// </summary>
        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
        };

        
        /// <inheritdoc/>
        public CheckInfo LoadCheckInfo()
        {
            if (!File.Exists(_checkInfoFilePath)) 
                return null;
            var json = File.ReadAllText(_checkInfoFilePath);
            var info = JsonSerializer.Deserialize<CheckInfo>(json);
            
            return info;
        }
        
        /// <inheritdoc/>
        public void SaveCheckInfo(CheckInfo info)
        {
            var json = JsonSerializer.Serialize(info, Options);
            
            File.Delete(_checkInfoFilePath);
            File.WriteAllText(_checkInfoFilePath, json);
        }
    }
}