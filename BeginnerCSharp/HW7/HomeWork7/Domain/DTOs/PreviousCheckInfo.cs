using System;

namespace Domain.DTOs
{
    public record PreviousCheckInfo(string CheckPath, DateTime LastCheck);
}