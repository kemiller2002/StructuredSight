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
    public class CallLogEntryIdAccess
    {
        private readonly IDataAccess _dataAccess;

        public CallLogEntryIdAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<CallLogEntryType> GetCallLogEntryId(Guid id)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("id", id));

            return _dataAccess.Get<CallLogEntryType>("dbo.CallLogEntryTypeSelect", kvps);
        }

        public IEnumerable<CallLogEntryType> GetCallLogEntryData()
        {
            var kvps = new List<KeyValuePair<string, object>>();

            return _dataAccess.Get<CallLogEntryType>("dbo.CallLogEntryTypeSelect", kvps);
        }
    }
}