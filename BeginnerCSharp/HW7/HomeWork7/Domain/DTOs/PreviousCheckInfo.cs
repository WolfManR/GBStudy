using System;

namespace Domain.DTOs
{
    /// <summary>
    /// Information about previous check
    /// </summary>
    public record PreviousCheckInfo(string CheckPath, DateTime LastCheck);
}