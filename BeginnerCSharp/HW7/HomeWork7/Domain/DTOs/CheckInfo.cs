using System.Collections.Generic;

namespace Domain.DTOs
{
    /// <summary>
    /// Check result information
    /// </summary>
    public class CheckInfo
    {
        public PreviousCheckInfo PreviousCheckInfo { get; init; }
        public List<ReadInfo> Info { get; init; }
    }
}