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
    public class SystemLogging
    {
        public int Id { get; set; }
        public Guid SystemLogId { get; set; }
        public string Module { get; set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string MachineName { get; set; }
        public string Username { get; set; }
        public string CallSite { get; set; }
        public string Thread { get; set; }
        public string Exception { get; set; }
        public string Stacktrace { get; set; }
        public string MethodName { get; set; }
        public string FilePath { get; set; }
        public int LineNumber { get; set; }
    }
}