using System.Collections.Generic;

namespace Task3.Models
{
    public class CheckInfo
    {
        public PreviousCheckInfo Previous { get; set; }
        public List<ReadInfo> Info { get; set; }
    }
}