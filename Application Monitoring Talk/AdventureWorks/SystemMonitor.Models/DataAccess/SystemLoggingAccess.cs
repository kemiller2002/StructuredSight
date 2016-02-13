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
    public class SystemLoggingAccess
    {
        private readonly IDataAccess _dataAccess;

        public SystemLoggingAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<SystemLogging> GetSystemLogging(int Id)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("@Id", Id));

            return _dataAccess.Get<SystemLogging>("dbo.SystemLoggingSelect", kvps);
        }

        public IEnumerable<SystemLogging> GetDates(DateTime beginDate, DateTime endDate)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("beginDate", beginDate.ToUniversalTime()));

            kvps.Add(new KeyValuePair<string, object>("endDate", endDate.ToUniversalTime()));

            return _dataAccess.Get<SystemLogging>("dbo.SystemLoggingSelect", kvps);
        }

        public IEnumerable<SystemLogging> GetSystemLogging()
        {
            var kvps = new List<KeyValuePair<string, object>>();

            return _dataAccess.Get<SystemLogging>("dbo.SystemLoggingSelect", kvps);
        }
    }
}