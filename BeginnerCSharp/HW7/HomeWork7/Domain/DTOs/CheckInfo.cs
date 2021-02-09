using System.Collections.Generic;

namespace Domain.DTOs
{
    public class CheckInfo
    {
        public PreviousCheckInfo Previous { get; init; }
        public List<ReadInfo> Info { get; init; }
    }
}