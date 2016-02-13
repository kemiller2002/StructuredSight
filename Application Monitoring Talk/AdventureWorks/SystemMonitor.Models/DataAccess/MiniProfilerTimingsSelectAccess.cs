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
    public class MiniProfilerTimingsSelectAccess
    {
        private readonly IDataAccess _dataAccess;

        public MiniProfilerTimingsSelectAccess(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<MiniProfilerTimings> GetMiniProfilerTimings(Guid MiniProfilerId)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("@MiniProfilerId", MiniProfilerId));

            return _dataAccess.Get<MiniProfilerTimings>("dbo.MiniProfilerTimingsSelect", kvps);
        }

        public IEnumerable<MiniProfilerTimings> GetDates(DateTime beginDate, DateTime endDate)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            kvps.Add(new KeyValuePair<string, object>("beginDate", beginDate));

            kvps.Add(new KeyValuePair<string, object>("endDate", endDate));

            return _dataAccess.Get<MiniProfilerTimings>("dbo.MiniProfilerTimingsSelect", kvps);
        }

        public IEnumerable<MiniProfilerTimings> GetMiniProfilerTimingsData(Guid? miniProfilerId = null)
        {
            var kvps = new List<KeyValuePair<string, object>>();

            if (miniProfilerId.HasValue)
            {
                kvps.Add(new KeyValuePair<string, object>("@MiniProfilerId", miniProfilerId));
            }

            return _dataAccess.Get<MiniProfilerTimings>("dbo.MiniProfilerTimingsSelect", kvps);
        }

    }
}