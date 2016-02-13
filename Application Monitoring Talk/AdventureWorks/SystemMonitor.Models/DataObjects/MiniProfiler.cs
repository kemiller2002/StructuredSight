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

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class HeaderAttribute : Attribute
{
    // See the attribute guidelines at 
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    // This is a positional argument
    public HeaderAttribute(string positionalString, int position)
    {
        PositionalString = positionalString;
    }

    public int Position { get; private set; }
    public string PositionalString { get; private set; }
}

namespace TCC.SystemMonitor.Models.DataObjects
{
    public class MiniProfiler
    {
        public int RowId { get; set; }

        [Header("Call Id", 0)]
        public Guid Id { get; set; }

        public Guid RootTimingId { get; set; }

        [Header("Timing Start", 1)]
        public DateTime Started { get; set; }

        [Header("Timing Length", 2)]
        public decimal DurationMilliseconds { get; set; }

        public string User { get; set; }
        public bool HasUserViewed { get; set; }

        [Header("Machine Name", 3)]
        public string MachineName { get; set; }

        [Header("Custom Links", 4)]
        public string CustomLinksJson { get; set; }

        public int? ClientTimingsRedirectCount { get; set; }
    }
}