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
    public class CallLogEntrySelect
    {
        public int CallLogEntryId { get; set; }
        public int CallLogEntryTypeId { get; set; }
        public Guid RequestIdentifier { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string Uri { get; set; }
    }
}