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
    public class MiniProfilerClientTimings
    {
        public Guid Id { get; set; }
        public Guid MiniProfilerId { get; set; }
        public string Name { get; set; }
        public decimal Start { get; set; }
        public decimal Duration { get; set; }
    }
}