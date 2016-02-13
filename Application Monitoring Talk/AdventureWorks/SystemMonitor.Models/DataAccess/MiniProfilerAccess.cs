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
    public class MiniProfilerAccess
    {
        private readonly IDataAccess _dataAccess; //has interface attached to it (always has the "I" before it)

        public MiniProfilerAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<MiniProfiler> GetMiniProfiler(Guid id)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("@id", id));

            return _dataAccess.Get<MiniProfiler>("dbo.MiniProfilersSelect", kvps);
                //<the generic> creates a collection with a commonality between diff types 
        }

        public IEnumerable<MiniProfiler> GetDates(DateTime beginDate, DateTime endDate)
        {
            var kvps = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("beginDate", beginDate.ToUniversalTime()),
                new KeyValuePair<string, object>("endDate", endDate.ToUniversalTime())
            };



            return _dataAccess.Get<MiniProfiler>("dbo.MiniProfilersSelect", kvps);
        }

        public IEnumerable<MiniProfiler> GetLiveData()
        {
            var kvps = new List<KeyValuePair<String, object>>();

            return _dataAccess.Get<MiniProfiler>("dbo.LiveGraphData", kvps);
        }


        public IEnumerable<MiniProfiler> GetMiniProfilerData()
        {
            var kvps = new List<KeyValuePair<string, object>>();

            return _dataAccess.Get<MiniProfiler>("dbo.MiniProfilersSelect", kvps);
        }
    }
}