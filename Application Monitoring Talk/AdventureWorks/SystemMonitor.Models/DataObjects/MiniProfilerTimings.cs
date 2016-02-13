#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using System;

#endregion

namespace TCC.SystemMonitor.Models.DataObjects
{
    public class MiniProfilerTimings
    {
        public Guid MiniProfilerId { get; set; }
        public Guid Id { get; set; }
        public Guid ParentTimingId { get; set; }
        public string Name { get; set; }
        public decimal DurationMilliseconds { get; set; }
        public decimal StartMilliseconds { get; set; }
        public bool IsRoot { get; set; }
        public int Depth { get; set; }
        public string CustomTimingsJson { get; set; }
    }
}