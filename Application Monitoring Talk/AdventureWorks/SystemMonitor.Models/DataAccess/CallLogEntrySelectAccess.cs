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
using System.Collections.Generic;
using TCC.SystemMonitor.Models.DataObjects;

#endregion

namespace TCC.SystemMonitor.Models.DataAccess
{
    public class CallLogEntrySelectAccess
    {
        private readonly IDataAccess _dataAccess;

        public CallLogEntrySelectAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<CallLogEntrySelect> GetCallLogEntry(Guid id)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("@id", id));

            return _dataAccess.Get<CallLogEntrySelect>("dbo.CallLogEntrySelect", kvps);
                //<the generic> creates a collection with a commonality between diff types 
        }

        public IEnumerable<CallLogEntrySelect> GetDates(DateTime beginDate, DateTime endDate)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("beginDate", beginDate.ToUniversalTime()));

            kvps.Add(new KeyValuePair<string, object>("endDate", endDate.ToUniversalTime()));

            return _dataAccess.Get<CallLogEntrySelect>("dbo.CallLogEntrySelect", kvps);
        }

        public IEnumerable<CallLogEntrySelect> GetCallLogEntryData()
        {
            var kvps = new List<KeyValuePair<string, object>>();

            return _dataAccess.Get<CallLogEntrySelect>("dbo.CallLogEntrySelect", kvps);
        }
    }
}